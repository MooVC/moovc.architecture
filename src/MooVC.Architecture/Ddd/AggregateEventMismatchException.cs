﻿namespace MooVC.Architecture.Ddd
{
    using System;
    using System.Runtime.Serialization;
    using MooVC.Architecture.Serialization;
    using static System.String;
    using static MooVC.Architecture.Ddd.Resources;
    using static MooVC.Ensure;

    [Serializable]
    public sealed class AggregateEventMismatchException
        : ArgumentException
    {
        public AggregateEventMismatchException(Reference aggregate, Reference eventAggregate)
            : base(FormatMessage(aggregate, eventAggregate))
        {
            Aggregate = aggregate;
            EventAggregate = eventAggregate;
        }

        private AggregateEventMismatchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Aggregate = info.TryGetReference(nameof(Aggregate));
            EventAggregate = info.TryGetReference(nameof(EventAggregate));
        }

        public Reference Aggregate { get; }

        public Reference EventAggregate { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            _ = info.TryAddReference(nameof(Aggregate), Aggregate);
            _ = info.TryAddReference(nameof(EventAggregate), EventAggregate);
        }

        private static string FormatMessage(Reference aggregate, Reference eventAggregate)
        {
            ArgumentNotNull(aggregate, nameof(aggregate), AggregateEventMismatchExceptionAggregateRequired);
            ArgumentNotNull(eventAggregate, nameof(eventAggregate), AggregateEventMismatchExceptionEventAggregateRequired);

            return Format(
                AggregateEventMismatchExceptionMessage,
                aggregate.Id,
                aggregate.Type.Name,
                aggregate.Version,
                eventAggregate.Id,
                eventAggregate.Type.Name,
                eventAggregate.Version);
        }
    }
}
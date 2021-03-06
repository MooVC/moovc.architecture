﻿namespace MooVC.Architecture.Ddd
{
    using System;
    using System.Runtime.Serialization;
    using MooVC.Serialization;
    using static MooVC.Architecture.Ddd.Resources;
    using static MooVC.Ensure;

    [Serializable]
    public abstract class DomainEvent
        : Message
    {
        protected DomainEvent(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Aggregate = info.GetValue<Reference>(nameof(Aggregate));
        }

        private protected DomainEvent(Message context, Reference aggregate)
            : base(context)
        {
            ArgumentNotNull(aggregate, nameof(aggregate), DomainEventAggregateRequired);

            Aggregate = aggregate;
        }

        public Reference Aggregate { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(Aggregate), Aggregate);
        }
    }
}
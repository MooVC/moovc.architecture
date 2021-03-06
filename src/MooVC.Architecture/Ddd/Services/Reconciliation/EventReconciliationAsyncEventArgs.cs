﻿namespace MooVC.Architecture.Ddd.Services.Reconciliation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Threading;
    using MooVC.Collections.Generic;
    using MooVC.Serialization;
    using static MooVC.Architecture.Ddd.Services.Reconciliation.Resources;
    using static MooVC.Ensure;

    [Serializable]
    public sealed class EventReconciliationAsyncEventArgs
        : AsyncEventArgs,
          ISerializable
    {
        public EventReconciliationAsyncEventArgs(
            IEnumerable<DomainEvent> events,
            CancellationToken? cancellationToken = default)
            : base(cancellationToken: cancellationToken)
        {
            ArgumentIsAcceptable(
                events,
                nameof(events),
                _ => events.Any(),
                EventReconciliationEventArgsEventsRequired);

            Events = events.Snapshot();
        }

        private EventReconciliationAsyncEventArgs(SerializationInfo info, StreamingContext context)
        {
            Events = info.TryGetEnumerable<DomainEvent>(nameof(Events));
        }

        public IEnumerable<DomainEvent> Events { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _ = info.TryAddEnumerable(nameof(Events), Events);
        }
    }
}
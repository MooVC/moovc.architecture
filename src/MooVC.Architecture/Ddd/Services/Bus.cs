namespace MooVC.Architecture.Ddd.Services
{
    using System;
    using System.Linq;
    using MooVC.Logging;

    public abstract class Bus
        : IBus
    {
        public event DomainEventsPublishedEventHandler Published;

        public event DomainEventsPublishingEventHandler Publishing;

        public event DomainEventsUnhandledEventHandler Unhandled;

        public void Publish(params DomainEvent[] events)
        {
            if (events.Any())
            {
                Publishing?.Invoke(this, new DomainEventsPublishingEventArgs(events));

                PerformPublish(events);

                Published?.Invoke(this, new DomainEventsPublishedEventArgs(events));
            }
        }

        protected abstract void PerformPublish(DomainEvent[] events);

        protected virtual void OnUnhandled(DomainEvent @event, Action handler)
        {
            Unhandled?.Invoke(this, new DomainEventsUnhandledEventArgs(@event, handler));
        }
    }
}
﻿namespace MooVC.Architecture.Ddd.Services
{
    using System.Linq;
    using MooVC.Architecture.Ddd.Services.Reconciliation;
    using static MooVC.Architecture.Ddd.Services.Resources;
    using static MooVC.Ensure;

    public sealed class DomainEventPropagator
    {
        private readonly IBus bus;
        private readonly IAggregateReconciler reconciler;

        public DomainEventPropagator(IBus bus, IAggregateReconciler reconciler)
        {
            ArgumentNotNull(bus, nameof(bus), DomainEventPropagatorBusRequired);
            ArgumentNotNull(reconciler, nameof(reconciler), DomainEventPropagatorReconcilerRequired);

            this.bus = bus;
            this.reconciler = reconciler;
            this.reconciler.AggregateReconciled += Reconciler_AggregateReconciled;
        }

        private async void Reconciler_AggregateReconciled(IAggregateReconciler sender, AggregateReconciledEventArgs e)
        {
            await bus
                .PublishAsync(e.Events.ToArray())
                .ConfigureAwait(false);
        }
    }
}
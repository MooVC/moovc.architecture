﻿namespace MooVC.Architecture.Ddd.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class SynchronousRepository<TAggregate>
        : Repository<TAggregate>
        where TAggregate : AggregateRoot
    {
        public override Task<IEnumerable<TAggregate>> GetAllAsync(CancellationToken? cancellationToken = default)
        {
            return Task.FromResult(PerformGetAll());
        }

        public override Task<TAggregate?> GetAsync(
            Guid id,
            CancellationToken? cancellationToken = default,
            SignedVersion? version = default)
        {
            return Task.FromResult(PerformGet(id, version: version));
        }

        protected override Task<Reference<TAggregate>?> GetCurrentVersionAsync(
            TAggregate aggregate,
            CancellationToken? cancellationToken = default)
        {
            return Task.FromResult(PerformGetCurrentVersion(aggregate));
        }

        protected override Task UpdateStoreAsync(
            TAggregate aggregate,
            CancellationToken? cancellationToken = default)
        {
            PerformUpdateStore(aggregate);

            return Task.CompletedTask;
        }

        protected abstract IEnumerable<TAggregate> PerformGetAll();

        protected abstract TAggregate? PerformGet(Guid id, SignedVersion? version = default);

        protected abstract Reference<TAggregate>? PerformGetCurrentVersion(TAggregate aggregate);

        protected abstract void PerformUpdateStore(TAggregate aggregate);
    }
}
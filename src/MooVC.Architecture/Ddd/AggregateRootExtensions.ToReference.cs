﻿namespace MooVC.Architecture.Ddd
{
    using static MooVC.Architecture.Ddd.Resources;
    using static MooVC.Ensure;

    public static partial class AggregateRootExtensions
    {
        public static Reference<TAggregate> ToReference<TAggregate>(
            this TAggregate aggregate,
            bool unversioned = false)
            where TAggregate : AggregateRoot
        {
            ArgumentNotNull(aggregate, nameof(aggregate), AggregateRootExtensionsToReferenceAggregateRequired);

            if (unversioned)
            {
                return new Reference<TAggregate>(aggregate.Id);
            }

            return new Reference<TAggregate>(aggregate);
        }
    }
}
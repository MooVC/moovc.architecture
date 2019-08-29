﻿namespace MooVC.Architecture.Ddd.ReferenceTests
{
    using System;
    using Moq;
    using Xunit;

    public sealed class WhenReferenceIsConstructed
    {
        [Theory]
        [InlineData(1ul)]
        [InlineData(18446744073709551615)]
        public void GivenAnAggregateThenTheIdTypeAndVersionArePropagated(ulong expectedVersion)
        {
            var expectedId = Guid.NewGuid();
            var aggregate = new Mock<AggregateRoot>(expectedId, expectedVersion);

            var reference = new Reference<AggregateRoot>(aggregate.Object);

            Assert.Equal(expectedId, reference.Id);
            Assert.Equal(typeof(AggregateRoot), reference.Type);
            Assert.Equal(expectedVersion, reference.Version);
        }

        [Theory]
        [InlineData(1ul)]
        [InlineData(18446744073709551615)]
        public void GivenAnAggregateIdAndVersionThenTheIdTypeAndVersionArePropagated(ulong expectedVersion)
        {
            var expectedId = Guid.NewGuid();

            var reference = new Reference<AggregateRoot>(expectedId, expectedVersion);

            Assert.Equal(expectedId, reference.Id);
            Assert.Equal(typeof(AggregateRoot), reference.Type);
            Assert.Equal(expectedVersion, reference.Version);
        }
    }
}
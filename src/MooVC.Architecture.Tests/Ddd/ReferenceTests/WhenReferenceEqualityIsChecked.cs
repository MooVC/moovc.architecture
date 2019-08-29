﻿namespace MooVC.Architecture.Ddd.ReferenceTests
{
    using System;
    using Xunit;

    public class WhenReferenceEqualityIsChecked
    {
        [Fact]
        public void GivenTwoSeparateInstancesWithTheSameIdAndTypeAndVersionThenBothAreConsideredEqual()
        {
            var aggregateId = Guid.NewGuid();
            ulong version = 1;

            var first = new Reference<AggregateRoot>(aggregateId, version: version);
            var second = new Reference<AggregateRoot>(aggregateId, version: version);

            Assert.True(first == second);
        }

        [Fact]
        public void GivenTwoSeparateInstancesWithTheSameIdTypeAndDifferentVersionThenBothAreNotConsideredEqual()
        {
            var aggregateId = Guid.NewGuid();
            
            var first = new Reference<AggregateRoot>(aggregateId, version: 1);
            var second = new Reference<AggregateRoot>(aggregateId, version: 2);

            Assert.True(first != second);
        }
    }
}
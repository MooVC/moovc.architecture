namespace MooVC.Architecture.Ddd.Services.ConcurrentMemoryRepositoryTests
{
    using System;
    using MooVC.Architecture.Ddd.AggregateRootTests;
    using MooVC.Architecture.Ddd.EventCentricAggregateRootTests;
    using MooVC.Architecture.MessageTests;
    using Xunit;

    public sealed class WhenGetIsCalled
        : ConcurrentMemoryRepositoryTests
    {
        [Fact]
        public void GivenAnIdWhenAnExistingEntryExistsThenTheEntryIsReturned()
        {
            var expected = new SerializableAggregateRoot();
            var other = new SerializableAggregateRoot();
            var repository = new ConcurrentMemoryRepository<SerializableAggregateRoot>(Cloner);

            repository.Save(expected);
            repository.Save(other);

            SerializableAggregateRoot? actual = repository.Get(expected.Id);

            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual!.Id);
            Assert.Equal(expected.Version, actual.Version);
            Assert.NotSame(expected, actual);
        }

        [Fact]
        public void GivenAnIdWhenNoExistingEntryExistsThenTheNullIsReturned()
        {
            var other = new SerializableAggregateRoot();
            var repository = new ConcurrentMemoryRepository<SerializableAggregateRoot>(Cloner);

            repository.Save(other);

            SerializableAggregateRoot? actual = repository.Get(Guid.NewGuid());

            Assert.Null(actual);
        }

        [Fact]
        public void GivenAnIdWhenTwoExistingVersionedEntriesExistThenTheMostUpToDateEntryIsReturned()
        {
            var aggregate = new SerializableEventCentricAggregateRoot();
            var other = new SerializableEventCentricAggregateRoot();
            var repository = new ConcurrentMemoryRepository<SerializableEventCentricAggregateRoot>(Cloner);

            repository.Save(aggregate);

            var context = new SerializableMessage();

            aggregate.Set(new SetRequest(context, Guid.NewGuid()));

            repository.Save(aggregate);
            repository.Save(other);

            SerializableEventCentricAggregateRoot? actual = repository.Get(aggregate.Id);

            Assert.NotSame(aggregate, actual);
            Assert.Equal(aggregate.Id, actual!.Id);
            Assert.Equal(aggregate.Version, actual.Version);
        }

        [Fact]
        public void GivenAVersionWhenTwoVersionedEntriesExistThenTheMatchingVersionedEntryIsReturned()
        {
            var aggregate = new SerializableEventCentricAggregateRoot();
            SignedVersion expectedFirst = aggregate.Version;
            var repository = new ConcurrentMemoryRepository<SerializableEventCentricAggregateRoot>(Cloner);

            repository.Save(aggregate);

            var context = new SerializableMessage();

            aggregate.Set(new SetRequest(context, Guid.NewGuid()));

            SignedVersion expectedSecond = aggregate.Version;

            repository.Save(aggregate);

            var other = new SerializableEventCentricAggregateRoot();

            repository.Save(other);

            SerializableEventCentricAggregateRoot? actualFirst = repository.Get(aggregate.Id, version: expectedFirst);
            SerializableEventCentricAggregateRoot? actualSecond = repository.Get(aggregate.Id, version: expectedSecond);

            Assert.NotNull(actualFirst);
            Assert.NotSame(expectedFirst, actualFirst);
            Assert.Equal(aggregate.Id, actualFirst!.Id);
            Assert.Equal(expectedFirst, actualFirst.Version);

            Assert.NotNull(actualSecond);
            Assert.NotSame(expectedSecond, actualSecond);
            Assert.Equal(aggregate.Id, actualSecond!.Id);
            Assert.Equal(expectedSecond, actualSecond.Version);
        }

        [Fact]
        public void GivenAVersionWhenNoExistingVersionedEntryMatchesThenNullIsReturned()
        {
            var aggregate = new SerializableAggregateRoot();
            var other = new SerializableAggregateRoot();
            var repository = new ConcurrentMemoryRepository<SerializableAggregateRoot>(Cloner);

            repository.Save(aggregate);
            repository.Save(other);

            SerializableAggregateRoot? actual = repository.Get(aggregate.Id, version: other.Version);

            Assert.Null(actual);
        }
    }
}
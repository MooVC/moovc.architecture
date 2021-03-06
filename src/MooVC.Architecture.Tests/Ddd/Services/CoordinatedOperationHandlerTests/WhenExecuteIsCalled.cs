﻿namespace MooVC.Architecture.Ddd.Services.CoordinatedOperationHandlerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MooVC.Architecture.Ddd.EventCentricAggregateRootTests;
    using MooVC.Architecture.MessageTests;
    using Moq;
    using Xunit;

    public sealed class WhenExecuteIsCalled
    {
        [Fact]
        public async Task GivenACommandThenTheAggregateIsRetrievedTheSetOperationInvokedAndTheChangesSavedAsync()
        {
            var identity = Guid.NewGuid();
            var repository = new Mock<IRepository<SerializableEventCentricAggregateRoot>>();
            var handler = new TestableCoordinatedOperationHandler<Message>(identity, repository.Object);
            var command = new SerializableMessage();
            var aggregate = new SerializableEventCentricAggregateRoot(identity);

            Assert.NotEqual(identity, aggregate.Value);

            _ = repository
                .Setup(repo => repo.GetAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken?>(),
                    It.IsAny<SignedVersion?>()))
                .ReturnsAsync(aggregate);

            await handler.ExecuteAsync(command, CancellationToken.None);

            Assert.Equal(identity, aggregate.Value);

            repository.Verify(
                repo => repo.SaveAsync(
                    It.IsAny<SerializableEventCentricAggregateRoot>(),
                    It.IsAny<CancellationToken?>()),
                Times.Once);

            repository.Verify(
                repo => repo.SaveAsync(
                    It.Is<SerializableEventCentricAggregateRoot>(source => source == aggregate),
                    It.IsAny<CancellationToken?>()),
                Times.Once);
        }
    }
}
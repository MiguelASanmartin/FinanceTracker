using FinanceTracker.Application.Budgets;
using FinanceTracker.Domain;
using FinanceTracker.Domain.Budgets;
using Moq;

namespace FinanceTracker.UnitTests.Budgets
{
    public class RegisterBudgetCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsGuid()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(7, 2026);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task Handle_ValidCommand_RepositoryCalled()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(7, 2026);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepo.Verify(r => r.SaveAsync(It.IsAny<Budget>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task Handle_NegativeMonth_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(-2, 2026);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_MonthGreaterThan12_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(20, 2026);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_NegativeYear_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(7, -500);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_YearBefore2002_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(7, 2000);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_FutureYear_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new RegisterBudgetCommandHandler(mockRepo.Object);
            var command = new RegisterBudgetCommand(7, 2050);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}

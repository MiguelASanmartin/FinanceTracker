using FinanceTracker.Application.Budgets;
using FinanceTracker.Domain;
using FinanceTracker.Domain.Budgets;
using Moq;

namespace FinanceTracker.UnitTests.Budgets
{
    public class IncreaseBudgetCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCommand_RepositoryCalled()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new DecreaseBudgetCommandHandler(mockRepo.Object);
            var budget = new Budget(7, 2026);
            var command = new DecreaseBudgetCommand(budget.Month, budget.Year, 200);

            mockRepo.Setup(r => r.GetByMonthAndYearAsync(budget.Month, budget.Year, It.IsAny<CancellationToken>()))
                .ReturnsAsync(budget);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepo.Verify(r => r.GetByMonthAndYearAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()));
            mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Budget>(), It.IsAny<CancellationToken>()));

        }

        [Fact]
        public async Task Handle_NegativeValue_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new IncreaseBudgetCommandHandler(mockRepo.Object);
            var budget = new Budget(7, 2026);
            var command = new IncreaseBudgetCommand(budget.Month, budget.Year, -200);

            mockRepo.Setup(r => r.GetByMonthAndYearAsync(budget.Month, budget.Year, It.IsAny<CancellationToken>()))
                .ReturnsAsync(budget);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ZeroValue_ThrowsDomainException()
        {
            var mockRepo = new Mock<IBudgetRepository>();
            var handler = new IncreaseBudgetCommandHandler(mockRepo.Object);
            var budget = new Budget(7, 2026);
            var command = new IncreaseBudgetCommand(budget.Month, budget.Year, 0);

            mockRepo.Setup(r => r.GetByMonthAndYearAsync(budget.Month, budget.Year, It.IsAny<CancellationToken>()))
                .ReturnsAsync(budget);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}

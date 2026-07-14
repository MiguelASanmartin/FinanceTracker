using FinanceTracker.Application.Expenses;
using FinanceTracker.Domain;
using FinanceTracker.Domain.Expenses;
using Moq;

namespace FinanceTracker.UnitTests.Expenses
{
    public class RegisterExpenseCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsGuid()
        {
            var mockRepo = new Mock<IExpenseRepository>();
            var handler = new RegisterExpenseCommandHandler(mockRepo.Object);
            var command = new RegisterExpenseCommand(100, Guid.NewGuid(), Guid.NewGuid(), "Test", DateOnly.FromDateTime(DateTime.Now));

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task Handle_ValidCommand_RepositoryCalled()
        {
            var mockRepo = new Mock<IExpenseRepository>();
            var handler = new RegisterExpenseCommandHandler(mockRepo.Object);
            var command = new RegisterExpenseCommand(100, Guid.NewGuid(), Guid.NewGuid(), "Test", DateOnly.FromDateTime(DateTime.Now));

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepo.Verify(r => r.SaveAsync(It.IsAny<Expense>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_NegativeExpense_ThrowsInvalidAmountException()
        {
            var mockRepo = new Mock<IExpenseRepository>();
            var handler = new RegisterExpenseCommandHandler(mockRepo.Object);
            var command = new RegisterExpenseCommand(-100, Guid.NewGuid(), Guid.NewGuid(), "Test", DateOnly.FromDateTime(DateTime.Now));

            await Assert.ThrowsAsync<InvalidAmountException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}

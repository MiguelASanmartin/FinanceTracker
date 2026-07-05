using FinanceTracker.Application.Accounts;
using FinanceTracker.Domain;
using FinanceTracker.Domain.Accounts;
using Moq;

namespace FinanceTracker.UnitTests.Accounts
{
    public class RegisterAccountCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsGuid()
        {
            var mockRepo = new Mock<IAccountRepository>();
            var handler = new RegisterAccountCommandHandler(mockRepo.Object);
            var command = new RegisterAccountCommand("Test", AccountType.Cash, 100);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task Handle_ValidCommand_RepositoryCalled()
        {
            var mockRepo = new Mock<IAccountRepository>();
            var handler = new RegisterAccountCommandHandler(mockRepo.Object);
            var command = new RegisterAccountCommand("Test", AccountType.Cash, 100);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepo.Verify(r => r.SaveAsync(It.IsAny<Account>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_EmptyName_ThrowsDomainException()
        {
            var mockRepo = new Mock<IAccountRepository>();
            var handler = new RegisterAccountCommandHandler(mockRepo.Object);
            var command = new RegisterAccountCommand("", AccountType.Cash, 100);

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}

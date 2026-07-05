using FinanceTracker.Application.Categories;
using FinanceTracker.Domain;
using FinanceTracker.Domain.Categories;
using Moq;

namespace FinanceTracker.UnitTests.Categories
{
    public class RegisterCategoryCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsGuid()
        {
            var mockRepo = new Mock<ICategoryRepository>();
            var handler = new RegisterCategoryCommandHandler(mockRepo.Object);
            var command = new RegisterCategoryCommand("Test");

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task Handle_ValidCommand_RepositoryCalled()
        {
            var mockRepo = new Mock<ICategoryRepository>();
            var handler = new RegisterCategoryCommandHandler(mockRepo.Object);
            var command = new RegisterCategoryCommand("Test");

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepo.Verify(r => r.SaveAsync(It.IsAny<Category>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_EmptyName_ThrowsDomainException()
        {
            var mockRepo = new Mock<ICategoryRepository>();
            var handler = new RegisterCategoryCommandHandler(mockRepo.Object);
            var command = new RegisterCategoryCommand("");

            await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}

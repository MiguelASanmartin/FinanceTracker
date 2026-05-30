using FinanceTracker.Domain.Categories;
using MediatR;

namespace FinanceTracker.Application.Categories
{
    public class RegisterCategoryCommandHandler : IRequestHandler<RegisterCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;

        public RegisterCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(RegisterCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            await _repository.SaveAsync(category, cancellationToken);

            return category.Id;
        }
    }
}

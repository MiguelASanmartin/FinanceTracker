using FinanceTracker.Domain.Categories;

namespace FinanceTracker.Application.Categories
{
    public interface ICategoryRepository 
    {
        Task SaveAsync(Category category, CancellationToken cancellation);
    }
}

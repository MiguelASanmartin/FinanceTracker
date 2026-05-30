using FinanceTracker.Application.Categories;
using FinanceTracker.Domain.Categories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly FinanceTrackerDbContext _context;

        public CategoryRepository(FinanceTrackerDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Category category, CancellationToken cancellationToken)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

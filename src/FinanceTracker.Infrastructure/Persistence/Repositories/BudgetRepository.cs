using FinanceTracker.Application.Budgets;
using FinanceTracker.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories
{
    public sealed class BudgetRepository : IBudgetRepository
    {
        private readonly FinanceTrackerDbContext _context;

        public BudgetRepository(FinanceTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Budget?> GetByMonthAndYearAsync(int month, int year, CancellationToken cancellationToken)
        {
            return await _context.Budgets
                .FirstOrDefaultAsync(b => b.Month == month && b.Year == year,
                cancellationToken);
        }

        public async Task SaveAsync(Budget budget, CancellationToken cancellationToken)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Budget budget, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

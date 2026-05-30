using FinanceTracker.Application.Expenses;
using FinanceTracker.Domain.Expenses;

namespace FinanceTracker.Infrastructure.Persistence.Repositories
{
    public sealed class ExpenseRepository : IExpenseRepository
    {
        private readonly FinanceTrackerDbContext _context;

        public ExpenseRepository(FinanceTrackerDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Expense expense, CancellationToken cancellationToken)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

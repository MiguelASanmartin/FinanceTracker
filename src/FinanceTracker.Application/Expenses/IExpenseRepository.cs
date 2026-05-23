using FinanceTracker.Domain.Expenses;

namespace FinanceTracker.Application.Expenses
{
    public interface IExpenseRepository
    {
        Task SaveAsync(Expense expense, CancellationToken cancellationToken);
    }
}

using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Application.Budgets
{
    public interface IBudgetRepository
    {
        Task SaveAsync(Budget budget, CancellationToken cancellationToken);

        Task UpdateAsync(Budget budget, CancellationToken cancellationToken);

        Task<Budget?> GetByMonthAndYearAsync(int month, int year, CancellationToken cancellationToken);
    }
}

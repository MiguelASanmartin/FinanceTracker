using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Application.Accounts
{
    public interface IAccountRepository
    {
        Task SaveAsync(Account account, CancellationToken cancellationToken);
    }
}

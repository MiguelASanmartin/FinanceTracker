using FinanceTracker.Application.Accounts;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Infrastructure.Persistence.Repositories
{
    public sealed class AccountRepository : IAccountRepository
    {
        private readonly FinanceTrackerDbContext _context;

        public AccountRepository(FinanceTrackerDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Account account, CancellationToken cancellationToken)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

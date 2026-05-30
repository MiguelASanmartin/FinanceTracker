using FinanceTracker.Domain.Accounts;
using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence
{
    public sealed class FinanceTrackerDbContext : DbContext
    {
        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<Expense> Expenses => Set<Expense>();

        public DbSet<Account> Accounts => Set<Account>();

        public DbSet<Category> Categories => Set<Category>();
    }
}

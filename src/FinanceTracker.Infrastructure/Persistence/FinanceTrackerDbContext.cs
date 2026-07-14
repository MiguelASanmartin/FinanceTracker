using FinanceTracker.Domain.Accounts;
using FinanceTracker.Domain.Budgets;
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

        public DbSet<Budget> Budgets => Set<Budget>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .OwnsOne(e => e.Amount, a => a.Property(x => x.Value).HasPrecision(18, 2));

            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Budget>()
                .Property(a => a.TotalSpent)
                .HasPrecision(18, 2);   
        }
    }
}

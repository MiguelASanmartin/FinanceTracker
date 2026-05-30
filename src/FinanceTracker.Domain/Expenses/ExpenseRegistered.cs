namespace FinanceTracker.Domain.Expenses
{
    public class ExpenseRegistered : IDomainEvent
    {
        public Guid ExpenseId { get; }

        public DateOnly Date { get; }

        public Amount Amount { get; }

        public ExpenseRegistered(Guid expenseId, DateOnly date, Amount amount)
        {
            ExpenseId = expenseId;
            Date = date;
            Amount = amount;
        }
    }
}

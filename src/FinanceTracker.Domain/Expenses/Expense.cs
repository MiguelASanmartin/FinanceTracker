namespace FinanceTracker.Domain.Expenses
{
    public sealed class Expense : AggregateRoot
    {
        public Amount Amount { get; private set; } = null!;

        public Guid AccountId { get; private set; }

        public Guid CategoryId { get; private set; }

        public string Concept { get; private set; } = null!;

        public DateOnly Date { get; private set; }

        private Expense() { } //EF Core

        public Expense(decimal amount, Guid accountId, Guid categoryId, string concept, DateOnly date)
        {
            Amount = new Amount(amount);
            AccountId = accountId;
            CategoryId = categoryId;
            Concept = ValidateConcept(concept);
            Date = date;
            AddEvent(new ExpenseRegistered(Id, Date, Amount));
        }

        public void UpdateAmount(decimal amount) 
        {
            Amount = new Amount(amount);
        }

        public void UpdateAccount(Guid accountId)
        {
            AccountId = accountId;
        }

        public void UpdateCategory(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public void UpdateConcept(string concept)
        {
            Concept = ValidateConcept(concept);
        }

        public void UpdateDate(DateOnly date)
        {
            Date = date;
        }

        private string ValidateConcept(string concept)
        {
            return !string.IsNullOrEmpty(concept) ? concept : throw new DomainException($"Concept can not be blank, got {concept}");
        }
    }
}

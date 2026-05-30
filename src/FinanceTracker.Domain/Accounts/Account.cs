namespace FinanceTracker.Domain.Accounts
{
    public class Account : AggregateRoot
    {
        public string Name { get; private set; } = null!;

        public AccountType Type { get; private set; }

        public decimal Balance { get; private set; }

        private Account() { } //EF Core

        public Account(string name, AccountType type, decimal balance) 
        {
            Name = ValidateName(name);
            Type = type;
            Balance = balance;
        }

        public void UpdateName(string name)
        {
            Name = ValidateName(name);
        }

        public void UpdateType(AccountType type)
        {
            Type = type;
        }

        public void Deposit(decimal amount)
        {
            Balance += ValidateAmount(amount);
        }

        public void Withdraw(decimal amount)
        {
            Balance -= ValidateAmount(amount);
        }

        private string ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) ? name : throw new DomainException($"Name can not be blank, got {name}");
        }

        private decimal ValidateAmount(decimal amount)
        {
            return amount > 0 ? amount : throw new DomainException($"Amount can not be zero or below, got {amount}");
        }
    }
}

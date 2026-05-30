namespace FinanceTracker.Domain.Categories
{
    public class Category : AggregateRoot
    {
        public string Name { get; private set; } = null!;

        private Category() { } //EF Core

        public Category(string name)
        {
            Name = ValidateName(name);
        }

        public void UpdateName(string name)
        {
            Name = ValidateName(name);
        }

        private string ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) ? name : throw new DomainException($"Name can not be blank, got {name}");
        }
    }
}

namespace FinanceTracker.Domain.Expenses
{
    public sealed class Amount : IEquatable<Amount>
    {
        public decimal Value { get; }

        private Amount() { }

        public Amount(decimal value) 
        {
            if (value <= 0) throw new InvalidAmountException($"Amount must be greater than zero, got {value}");

            Value = value; 
        }

        public bool Equals(Amount? other)
        {
            return other is not null && Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Amount);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}

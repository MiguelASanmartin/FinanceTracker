namespace FinanceTracker.Domain
{
    public class InvalidAmountException : DomainException
    {
        public InvalidAmountException(string message) : base(message) { }
    }
}

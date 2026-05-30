namespace FinanceTracker.Domain
{
    public class AggregateRoot : Entity
    {
        public List<IDomainEvent> Events { get; }

        public AggregateRoot()
        {
            Events = new List<IDomainEvent>();
        }

        public void AddEvent(IDomainEvent e)
        {
            Events.Add(e);
        }
    }
}

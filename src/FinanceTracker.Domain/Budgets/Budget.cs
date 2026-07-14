namespace FinanceTracker.Domain.Budgets
{
    public class Budget : AggregateRoot
    {
        public int Month { get; private set; }

        public int Year { get; private set; }

        public decimal TotalSpent { get; private set; }

        protected Budget() { } //Protected for tests.

        public Budget(int month, int year)
        {
            Month = ValidateMonth(month);
            Year = ValidateYear(year);
            TotalSpent = 0;
        }

        public void IncreaseTotalSpent(decimal value)
        {
            if (value < 0) throw new DomainException($"Value to increase can not be negative, got {value}");
            if (value == 0) throw new DomainException($"Value to increase can not be zero, got {value}");
            TotalSpent += value;
        }

        public void DecreaseTotalSpent(decimal value)
        {
            if (value < 0) throw new DomainException($"Value to decrease can not be negative, got {value}");
            if (value == 0) throw new DomainException($"Value to decrease can not be zero, got {value}");
            TotalSpent -= value;
        }

        private int ValidateMonth(int month)
        {
            if (month < 1) throw new DomainException($"Month can not be negative, got {month}");
            if (month > 12) throw new DomainException($"Month can not be greater than 12, got {month}");

            return month;
        }

        private int ValidateYear(int year)
        {
            if (year < 0) throw new DomainException($"Year can not be negative, got {year}");
            // Year the euro was introduced in Spain
            if (year < 2002) throw new DomainException($"Years before 2002 are not supported, got {year}");
            if (year > DateOnly.FromDateTime(DateTime.Now).Year) throw new DomainException($"Years can not be greater than actual year, got {year}");

            return year;
        }
    }
}

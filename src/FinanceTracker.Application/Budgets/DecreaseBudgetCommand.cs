using MediatR;

namespace FinanceTracker.Application.Budgets
{
    public record DecreaseBudgetCommand(int Month, int Year, decimal Value) : IRequest<Unit>;
}

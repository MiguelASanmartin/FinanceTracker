using MediatR;

namespace FinanceTracker.Application.Budgets
{
    public record IncreaseBudgetCommand(int Month, int Year, decimal Value) : IRequest<Unit>;
}

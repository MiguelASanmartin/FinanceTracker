using MediatR;

namespace FinanceTracker.Application.Budgets
{
    public record RegisterBudgetCommand(int Month, int Year) : IRequest<Guid>;
}

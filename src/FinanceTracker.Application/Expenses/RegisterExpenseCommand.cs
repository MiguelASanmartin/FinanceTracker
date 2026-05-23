using MediatR;

namespace FinanceTracker.Application.Expenses
{
    public record RegisterExpenseCommand(decimal Amount, Guid AccountId, Guid CategoryId, string Concept, DateOnly Date) : IRequest<Guid>;
}

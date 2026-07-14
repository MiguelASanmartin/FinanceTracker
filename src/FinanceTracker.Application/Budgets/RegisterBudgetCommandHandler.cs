using FinanceTracker.Domain.Budgets;
using MediatR;

namespace FinanceTracker.Application.Budgets
{
    public class RegisterBudgetCommandHandler : IRequestHandler<RegisterBudgetCommand, Guid>
    {
        private readonly IBudgetRepository _repository;

        public RegisterBudgetCommandHandler(IBudgetRepository budgetRepository)
        {
            _repository = budgetRepository;
        }

        public async Task<Guid> Handle(RegisterBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = new Budget(request.Month, request.Year);

            await _repository.SaveAsync(budget, cancellationToken);

            return budget.Id;
        }
    }
}

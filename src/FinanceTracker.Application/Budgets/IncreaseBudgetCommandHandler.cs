using FinanceTracker.Domain;
using MediatR;

namespace FinanceTracker.Application.Budgets
{
    public class IncreaseBudgetCommandHandler : IRequestHandler<IncreaseBudgetCommand, Unit>
    {
        private readonly IBudgetRepository _repository;

        public IncreaseBudgetCommandHandler(IBudgetRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(IncreaseBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _repository.GetByMonthAndYearAsync(request.Month, request.Year, cancellationToken);

            if (budget == null) throw new NotFoundException($"Not found budget for month {request.Month} and year {request.Year}");

            budget.IncreaseTotalSpent(request.Value);

            await _repository.UpdateAsync(budget, cancellationToken);

            return Unit.Value;
        }
    }
}

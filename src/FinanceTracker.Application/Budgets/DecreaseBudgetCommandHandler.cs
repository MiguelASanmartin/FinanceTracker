using FinanceTracker.Domain;
using MediatR;

namespace FinanceTracker.Application.Budgets
{
    public class DecreaseBudgetCommandHandler : IRequestHandler<DecreaseBudgetCommand, Unit>
    {
        private readonly IBudgetRepository _repository;

        public DecreaseBudgetCommandHandler(IBudgetRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DecreaseBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _repository.GetByMonthAndYearAsync(request.Month, request.Year, cancellationToken);

            if (budget == null) throw new NotFoundException($"Not found budget for month {request.Month} and year {request.Year}");

            budget.DecreaseTotalSpent(request.Value);

            await _repository.UpdateAsync(budget, cancellationToken);

            return Unit.Value; 
        }
    }
}

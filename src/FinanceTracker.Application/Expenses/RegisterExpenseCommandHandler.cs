using FinanceTracker.Domain.Expenses;
using MediatR;

namespace FinanceTracker.Application.Expenses
{
    public class RegisterExpenseCommandHandler : IRequestHandler<RegisterExpenseCommand, Guid>
    {

        private readonly IExpenseRepository _repository;

        public RegisterExpenseCommandHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(RegisterExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense(request.Amount, request.AccountId, request.CategoryId, request.Concept, request.Date);

            await _repository.SaveAsync(expense, cancellationToken);

            return expense.Id;
        }
    }
}

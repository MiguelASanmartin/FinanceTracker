using FinanceTracker.Domain.Accounts;
using MediatR;

namespace FinanceTracker.Application.Accounts
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Guid>
    {

        private readonly IAccountRepository _repository;

        public RegisterAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(request.Name, request.Type, request.Balance);

            await _repository.SaveAsync(account, cancellationToken);

            return account.Id;
        }
    }
}

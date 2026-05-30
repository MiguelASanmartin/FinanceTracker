using FinanceTracker.Domain.Accounts;
using MediatR;

namespace FinanceTracker.Application.Accounts
{
    public record RegisterAccountCommand(string Name, AccountType Type, decimal Balance) : IRequest<Guid>;
}

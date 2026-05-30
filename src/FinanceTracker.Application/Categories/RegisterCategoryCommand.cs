using MediatR;

namespace FinanceTracker.Application.Categories
{
    public record RegisterCategoryCommand(string Name) : IRequest<Guid>;
}

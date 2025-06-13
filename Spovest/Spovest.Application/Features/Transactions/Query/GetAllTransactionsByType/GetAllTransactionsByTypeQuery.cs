using MediatR;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactionsByType
{
    public record GetAllTransactionsByTypeQuery(string type) : IRequest<IEnumerable<TransactionDto>>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactionsByUserId
{
    public record GetAllTransactionsByUserIdQuery(int id) : IRequest<IEnumerable<TransactionDto>>;
}

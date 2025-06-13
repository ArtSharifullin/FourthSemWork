using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities.Enums;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactionsByUserIdAndType
{
    public record GetAllTransactionsByUserIdAndTypeQuery(int id, string type) : IRequest<IEnumerable<TransactionDto>>;
}

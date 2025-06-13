using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactionsByUserIdAndType
{
    public class GetAllTransactionsByUserIdAndTypeQueryHandler : IRequestHandler<GetAllTransactionsByUserIdAndTypeQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsByUserIdAndTypeQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsByUserIdAndTypeQuery query, CancellationToken ct)
        {
            var data = await _transactionRepository.GetAllTransactionsByUserIdAndTypeAsync(query.id, query.type);
            var result = data.Select(e => new TransactionDto
            {
                Id = e.Id,
                UserId = e.UserId,
                OperationType = e.OperationType,
                Cost = e.Cost,
                CreatedDate = e.CreatedDate,
            });

            return result ?? new List<TransactionDto>() { };
        }
    }
}

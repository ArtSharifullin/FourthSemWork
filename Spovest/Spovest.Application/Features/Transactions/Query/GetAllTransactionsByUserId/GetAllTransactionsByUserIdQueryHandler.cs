using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactionsByUserId
{
    public class GetAllTransactionsByUserIdQueryHandler : IRequestHandler<GetAllTransactionsByUserIdQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsByUserIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsByUserIdQuery query, CancellationToken ct)
        {
            var data = await _transactionRepository.GetAllTransactionsByUserIdAsync(query.id);
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

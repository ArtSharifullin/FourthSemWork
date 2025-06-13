using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactionsByType
{
    public class GetAllTransactionsByTypeQueryHandler : IRequestHandler<GetAllTransactionsByTypeQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsByTypeQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsByTypeQuery query, CancellationToken ct)
        {
            var data = await _transactionRepository.GetAllTransactionsByTypeAsync(query.type);
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

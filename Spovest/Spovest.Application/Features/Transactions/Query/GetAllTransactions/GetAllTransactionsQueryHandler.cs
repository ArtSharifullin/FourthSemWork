using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Transactions.Query.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery query, CancellationToken ct)
        {
            var data = await _transactionRepository.GetAllTransactionsAsync();
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

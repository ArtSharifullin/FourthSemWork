using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities.Enums;

namespace Spovest.Application.Features.Transactions.Query
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OperationType OperationType { get; set; }
        public decimal Cost { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

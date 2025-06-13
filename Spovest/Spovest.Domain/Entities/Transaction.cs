using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;
using Spovest.Domain.Entities.Enums;

namespace Spovest.Domain.Entities
{
    public class Transaction : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public OperationType OperationType { get; set; }
        public decimal Cost { get; set; }
    }
}

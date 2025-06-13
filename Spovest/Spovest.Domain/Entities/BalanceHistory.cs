using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;

namespace Spovest.Domain.Entities
{
    public class BalanceHistory : BaseAuditableEntity
    {
        public DateTime Date { get; set; }
        public decimal TotalBalance { get; set; }
    }
}

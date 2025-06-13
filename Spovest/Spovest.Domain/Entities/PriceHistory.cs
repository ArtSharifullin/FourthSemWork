using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;

namespace Spovest.Domain.Entities
{
    public class PriceHistory : BaseAuditableEntity
    {
        public int PlayerId { get; set; }
        public decimal? Purchase_price { get; set; }
        public decimal? Sale_price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

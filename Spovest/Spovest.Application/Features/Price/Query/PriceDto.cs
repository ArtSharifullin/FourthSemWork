using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spovest.Application.Features.Price.Query
{
    public class PriceDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public decimal? Purchase_price { get; set; }
        public decimal? Sale_price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

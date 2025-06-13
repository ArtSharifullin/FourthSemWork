using Spovest.Application.Features.Price.Query;

namespace Spovest.Areas.Admin.Models.PriceHistory
{
    public class PriceHistoryVM
    {
        public IEnumerable<PriceDto> Prices { get; set; }
    }
} 
using Spovest.Application.Features.Players.Query;

namespace Spovest.Areas.Admin.Models.Players
{
    public class PlayersVM
    {
        public IEnumerable<PlayersDto> Players { get; set; }
    }
}

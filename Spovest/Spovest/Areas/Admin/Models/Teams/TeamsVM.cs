using Spovest.Application.Features.Teams.Query;

namespace Spovest.Areas.Admin.Models.Teams
{
    public class TeamsVM
    {
        public IEnumerable<TeamsDto> Teams { get; set; }
    }
}

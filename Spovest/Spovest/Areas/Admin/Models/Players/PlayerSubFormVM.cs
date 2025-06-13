using System.ComponentModel.DataAnnotations;
using Spovest.Application.Features.Teams.Query;

namespace Spovest.Areas.Admin.Models.Players
{
    public class PlayerSubFormVM
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        public string? Name { get; set; }

        [StringLength(50, ErrorMessage = "Имя Команды не может быть длиннее 50 символов")]
        public string? TeamName { get; set; }

        public string? Img { get; set; }

        public int? Games { get; set; }

        public decimal? Points { get; set; }

        public decimal? Assists { get; set; }

        public decimal? Rebounds { get; set; }

        public decimal? Steals { get; set; }

        public decimal? Minutes { get; set; }

        public decimal? Ftps { get; set; }

        public IEnumerable<TeamsDto>? Teams { get; set; }
    }
}

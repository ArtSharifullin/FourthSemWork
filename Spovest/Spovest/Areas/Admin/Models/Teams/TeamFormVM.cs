using System.ComponentModel.DataAnnotations;

namespace Spovest.Areas.Admin.Models.Teams
{
    public class TeamFormVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Название команды обязательно")]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Изображение обязательно")]
        [StringLength(50, ErrorMessage = "Путь к изображению не может быть длиннее 50 символов")]
        public string Img { get; set; }
    }
} 
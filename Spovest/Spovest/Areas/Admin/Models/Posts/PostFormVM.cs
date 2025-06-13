using System.ComponentModel.DataAnnotations;

namespace Spovest.Areas.Admin.Models.Posts
{
    public class PostFormVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "UserID обязателен")]
        [Range(0, int.MaxValue, ErrorMessage = "Количество игр должно быть положительным числом")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Заголовок обязателен")]
        [StringLength(100, ErrorMessage = "Заголовок не может быть длиннее 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Содержание обязательно")]
        public string Content { get; set; }

        [StringLength(50, ErrorMessage = "Путь к изображению не может быть длиннее 50 символов")]
        public string Img { get; set; }
    }
} 
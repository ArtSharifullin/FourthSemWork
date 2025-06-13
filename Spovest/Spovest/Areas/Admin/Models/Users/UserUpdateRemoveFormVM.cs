using System.ComponentModel.DataAnnotations;

namespace Spovest.Areas.Admin.Models.Users
{
    public class UserUpdateRemoveFormVM
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов")]
        public string? Password { get; set; }

        [StringLength(50, ErrorMessage = "Название страны не может быть длиннее 50 символов")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Баланс обязателен")]
        public decimal? Balance { get; set; }
    }
}

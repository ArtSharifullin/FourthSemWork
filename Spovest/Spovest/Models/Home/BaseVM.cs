using System.ComponentModel.DataAnnotations;
using Spovest.Application.Features.Users.Query;

namespace Spovest.Models.Home
{
    public class BaseVM
    {
        public UserDto User { get; set; }

        [Required(ErrorMessage = "Your Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Body { get; set; }
    }
}

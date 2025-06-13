
using System.ComponentModel.DataAnnotations;

namespace Spovest.Areas.Admin.Models.PriceHistory
{
    public class PricesFormVM
    {
        public int? Id { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "ID Игрока должен быть положительным числом")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int PlayerId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Purchase_Price должен быть положительным числом")]
        [Required(ErrorMessage = "Обязательное поле")]
        public decimal? Purchase_Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Sale_Price должен быть положительным числом")]
        [Required(ErrorMessage = "Обязательное поле")]
        public decimal? Sale_Price { get; set; }
    }
}

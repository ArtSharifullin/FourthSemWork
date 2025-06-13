using System.ComponentModel.DataAnnotations;
using Spovest.Application.Features.Teams.Query;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Spovest.Areas.Admin.Models.Players
{
    public class PlayerFormVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя игрока обязательно")]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        [Display(Name = "Имя игрока")]
        public string Name { get; set; }

        
        [Display(Name = "Команда")]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "Количество игр обязательно")]
        [Range(0, int.MaxValue, ErrorMessage = "Количество игр должно быть положительным числом")]
        [Display(Name = "Количество игр")]
        public int Games { get; set; }

        [Required(ErrorMessage = "Количество очков обязательно")]
        [Range(0, double.MaxValue, ErrorMessage = "Количество очков должно быть положительным числом")]
        [Display(Name = "Очки")]
        public decimal Points { get; set; }

        [Required(ErrorMessage = "Количество передач обязательно")]
        [Range(0, double.MaxValue, ErrorMessage = "Количество передач должно быть положительным числом")]
        [Display(Name = "Передачи")]
        public decimal Assists { get; set; }

        [Required(ErrorMessage = "Количество подборов обязательно")]
        [Range(0, double.MaxValue, ErrorMessage = "Количество подборов должно быть положительным числом")]
        [Display(Name = "Подборы")]
        public decimal Rebounds { get; set; }

        [Required(ErrorMessage = "Количество перехватов обязательно")]
        [Range(0, double.MaxValue, ErrorMessage = "Количество перехватов должно быть положительным числом")]
        [Display(Name = "Перехваты")]
        public decimal Steals { get; set; }

        [Required(ErrorMessage = "Количество минут обязательно")]
        [Range(0, double.MaxValue, ErrorMessage = "Количество минут должно быть положительным числом")]
        [Display(Name = "Минуты")]
        public decimal Minutes { get; set; }

        [Required(ErrorMessage = "Процент попаданий со штрафных обязателен")]
        [Range(0, 100, ErrorMessage = "Процент должен быть от 0 до 100")]
        [Display(Name = "Процент штрафных")]
        public decimal Ftps { get; set; }

        public IEnumerable<TeamsDto>? Teams { get; set; }
    }
} 
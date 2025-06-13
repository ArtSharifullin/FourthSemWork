using System;

namespace Spovest.Application.Features.Balance.Query
{
    public class BalanceHistoryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalBalance { get; set; }
    }
} 
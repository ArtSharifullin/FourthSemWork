using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.CartItems.Query
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int Quantity { get; set; }
        public decimal PriceAtAdd { get; set; }
    }
}

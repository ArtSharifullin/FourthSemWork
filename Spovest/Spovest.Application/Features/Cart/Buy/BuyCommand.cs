using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Cart.Buy
{
    public class BuyCommand : IRequest<bool>
    {
        public int userId { get; set; }
        public int PlayerId { get; set; }
        public int Q {  get; set; }
    }
}

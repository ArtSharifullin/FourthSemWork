using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Price.Command.Create
{
    public class CreatePriceCommand : IRequest<bool>
    {
        public int playerId { get; set; }
        public decimal pprice { get; set; }
        public decimal sprice { get; set; }
    }
}

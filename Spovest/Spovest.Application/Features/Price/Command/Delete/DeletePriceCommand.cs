using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Price.Command.Delete
{
    public class DeletePriceCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}

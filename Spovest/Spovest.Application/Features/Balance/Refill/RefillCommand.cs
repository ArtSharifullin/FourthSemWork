using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Balance.Refill
{
    public class RefillCommand : IRequest<bool>
    {
        public int userId { get; set; }
    }
}

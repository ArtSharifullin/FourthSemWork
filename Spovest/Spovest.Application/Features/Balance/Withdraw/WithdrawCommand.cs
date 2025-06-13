using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Balance.Withdraw
{
    public class WithdrawCommand : IRequest<bool>
    {
        public int userId;
        public decimal q;
    }
}

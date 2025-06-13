using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Balance.Query.GetLastTotalBalance
{
    public record GetLastTotalBalanceQuery : IRequest<decimal>;
}

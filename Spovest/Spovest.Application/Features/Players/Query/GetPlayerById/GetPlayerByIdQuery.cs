using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Players.Query.GetPlayerById
{
    public record GetPlayerByIdQuery(int id) : IRequest<PlayersDto>;
}

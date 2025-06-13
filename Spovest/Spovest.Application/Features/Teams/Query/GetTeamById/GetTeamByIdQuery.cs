using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Teams.Query.GetTeamById
{
    public record GetTeamByIdQuery(int id) : IRequest<TeamsDto>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Teams.Query.GetAllTeamsRandom
{
    public class GetAllTeamsRandomQuery : IRequest<IEnumerable<TeamsDto>>;
}

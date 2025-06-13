using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Teams.Command.Create
{
    public class CreateTeamCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Img { get; set; }

    }
}

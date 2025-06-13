using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Players.Command.DeletePlayer
{
    public class DeletePlayerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

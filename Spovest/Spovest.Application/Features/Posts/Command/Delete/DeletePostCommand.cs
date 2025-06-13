using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Posts.Command.Delete
{
    public class DeletePostCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}

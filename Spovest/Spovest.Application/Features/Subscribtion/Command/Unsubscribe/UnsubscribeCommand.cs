using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Subscribtion.Command.Unsubscribe
{
    public class UnsubscribeCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
    }
}

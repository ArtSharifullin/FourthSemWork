using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Subscribtion.Command.Subscribe
{
    public class SubscribeCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
    }
}

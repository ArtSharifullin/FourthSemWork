using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Subscribtion.Command.Subscribe
{
    public class SubscribeCommandHandler : IRequestHandler<SubscribeCommand, bool>
    {
        private ISubscribeService _subscribeService;
        public SubscribeCommandHandler(ISubscribeService subscribeService) { _subscribeService = subscribeService; }
        public async Task<bool> Handle(SubscribeCommand command, CancellationToken cancellationToken) =>
            await _subscribeService.SubscribeAsync(command.UserId, command.FollowerId);
    }
}

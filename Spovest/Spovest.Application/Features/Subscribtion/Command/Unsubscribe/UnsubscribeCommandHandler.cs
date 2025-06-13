using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Subscribtion.Command.Unsubscribe
{
    public class UnsubscribeCommandHandler : IRequestHandler<UnsubscribeCommand, bool>
    {
        private ISubscribeService _subscribeService;
        public UnsubscribeCommandHandler(ISubscribeService subscribeService) { _subscribeService = subscribeService; }
        public async Task<bool> Handle(UnsubscribeCommand command, CancellationToken cancellationToken) =>
            await _subscribeService.UnsubscribeAsync(command.UserId, command.FollowerId);
    }
}

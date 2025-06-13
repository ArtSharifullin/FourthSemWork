using MediatR;
using Spovest.Application.Interfaces.Services;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.CurUser.GetCurrentAppUser
{
    public class GetCurrentAppUserQueryHandler : IRequestHandler<GetCurrentAppUserQuery, AppUser>
    {
        private readonly ICurrentUserService _currentUserService;
        public GetCurrentAppUserQueryHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<AppUser> Handle(GetCurrentAppUserQuery query, CancellationToken cancellationToken) =>
            await _currentUserService.GetCurrentAppUser();
    }
}

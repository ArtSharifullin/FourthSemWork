using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.CurUser.GetCurrentIdentityUser
{
    public class GetCurrentIdentityUserQueryHandler : IRequestHandler<GetCurrentIdentityUserQuery, IdentityUser>
    {
        private readonly ICurrentUserService _currentUserService;
        public GetCurrentIdentityUserQueryHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IdentityUser> Handle(GetCurrentIdentityUserQuery query, CancellationToken cancellationToken) =>
            await _currentUserService.GetCurrentIdentityUser();
    }
}

using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Spovest.Application.Features.CurUser.GetCurrentIdentityUser
{
    public record GetCurrentIdentityUserQuery : IRequest<IdentityUser>;
}

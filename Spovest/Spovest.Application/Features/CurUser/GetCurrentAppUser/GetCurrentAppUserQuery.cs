using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.CurUser.GetCurrentAppUser
{
    public record GetCurrentAppUserQuery : IRequest<AppUser>;
}

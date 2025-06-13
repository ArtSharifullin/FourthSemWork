using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Users.Query.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery query, CancellationToken ct)
        {
            var data = await _userRepository.GetAllUsersAsync();
            var result = data.Select(e => new UserDto
            {
                UserId = e.Id,
                IdentityId = e.IdentityId,
                Name = e.Name,
                Img = e.Img,
                Email = e.Email,
                Password = e.Password,
                Country = e.Country,
                Balance = e.Balance,
                IsWithdrawBlocked = e.IsWithdrawBlocked,
            });

            return result ?? new List<UserDto>() { };
        }
    }
}

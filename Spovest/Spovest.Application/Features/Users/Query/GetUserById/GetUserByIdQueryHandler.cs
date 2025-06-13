using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetPlayerById;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Users.Query.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery query, CancellationToken ct)
        {
            var data = await _userRepository.GetUserByIdAsync(query.id);
            if (data == null) { return new UserDto(); }
            var result = new UserDto
            {
                UserId = data.Id,
                IdentityId = data.IdentityId,
                Name = data.Name,
                Img = data.Img,
                Email = data.Email,
                Password = data.Password,
                Country = data.Country,
                Balance = data.Balance,
                IsWithdrawBlocked = data.IsWithdrawBlocked,
            };

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Features.Users.Query;

namespace Spovest.Application.Features.Subscribtion.Query.GetAllFollowers
{
    public class GetAllFollowersQueryHandler : IRequestHandler<GetAllFollowersQuery, IEnumerable<UserDto>>
    {
        private readonly ISubscribtionRepository _repository;

        public GetAllFollowersQueryHandler(ISubscribtionRepository repository) { _repository = repository; }

        public async Task<IEnumerable<UserDto>> Handle(GetAllFollowersQuery query, CancellationToken ct)
        {
            var data = await _repository.GetAllFollowersAsync(query.userId);
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
            });

            return result ?? new List<UserDto>() { };
        }
    }
}

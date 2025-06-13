using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Subscribtion.Query.GetAllFollowing;
using Spovest.Application.Features.Users.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Subscribtion.Query.GetAllSubscribtions
{
    public class GetAllSubscribtionsQueryHandler : IRequestHandler<GetAllSubscribtionsQuery, IEnumerable<SubscribtionDto>>
    {
        private readonly ISubscribtionRepository _repository;
        public GetAllSubscribtionsQueryHandler(ISubscribtionRepository repository) { _repository = repository; }

        public async Task<IEnumerable<SubscribtionDto>> Handle(GetAllSubscribtionsQuery query, CancellationToken ct)
        {
            var data = await _repository.GetAllSubscribtionAsync();
            var result = data.Select(e => new SubscribtionDto
            {
                AppUser = e.AppUser,
                AppUserId = e.AppUserId,    
                FollowerId = e.FollowerId,
                Follower = e.Follower,
            });

            return result ?? new List<SubscribtionDto>() { };
        }
    }
}

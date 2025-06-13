using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Teams.Query.GetAllTeamsRandom
{
    public class GetAllTeamsRandomQueryHandler : IRequestHandler<GetAllTeamsRandomQuery, IEnumerable<TeamsDto>>
    {
        private readonly ITeamRepository _teamRepository;

        public GetAllTeamsRandomQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamsDto>> Handle(GetAllTeamsRandomQuery query, CancellationToken ct)
        {
            var data = await _teamRepository.GetAllTeamsAsync();
            var result = data.Select(e => new TeamsDto
            {
                Id = e.Id,
                Name = e.Name,
                Img = e.Img,
            });

            return result ?? new List<TeamsDto>() { };
        }
    }
}

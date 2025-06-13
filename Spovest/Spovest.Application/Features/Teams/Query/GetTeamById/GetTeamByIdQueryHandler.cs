using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetPlayerById;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Teams.Query.GetTeamById
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamsDto>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamByIdQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamsDto> Handle(GetTeamByIdQuery query, CancellationToken ct)
        {
            var data = await _teamRepository.GetTeamByIdAsync(query.id);
            var result = new TeamsDto
            {
                Id = data.Id,
                Name = data.Name,
                Img = data.Img,
            };

            return result ?? new TeamsDto() { };
        }
    }
}

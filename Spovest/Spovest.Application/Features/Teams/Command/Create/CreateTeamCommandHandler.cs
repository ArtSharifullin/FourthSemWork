using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Teams.Command.Create
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, bool>
    {
        private readonly ITeamRepository _repository;
        public CreateTeamCommandHandler(ITeamRepository teamRepository) { _repository = teamRepository; }
        public async Task<bool> Handle(CreateTeamCommand command, CancellationToken ct) =>
            await _repository.CreateTeamAsync(command.Name, command.Img);
    }
}

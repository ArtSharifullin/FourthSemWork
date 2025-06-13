using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Teams.Command.Update
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, bool>
    {
        private readonly ITeamRepository _repository;
        public UpdateTeamCommandHandler(ITeamRepository teamRepository) { _repository = teamRepository; }
        public async Task<bool> Handle(UpdateTeamCommand command, CancellationToken ct) =>
            await _repository.UpdateTeamAsync(command.Id, command.Name, command.Img);
    }
}

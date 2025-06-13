using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Teams.Command.Delete
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly ITeamRepository _repository;
        public DeleteTeamCommandHandler(ITeamRepository teamRepository) { _repository = teamRepository; }
        public async Task<bool> Handle(DeleteTeamCommand command, CancellationToken ct) =>
            await _repository.DeleteTeamAsync(command.Id);
    }
}

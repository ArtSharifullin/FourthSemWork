using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.Teams.Command.Create;
using Spovest.Application.Features.Teams.Command.Delete;
using Spovest.Application.Features.Teams.Command.Update;
using Spovest.Application.Features.Teams.Query.GetAllTeamsRandom;
using Spovest.Application.Features.Teams.Query.GetTeamById;
using Spovest.Areas.Admin.Models.Players;
using Spovest.Areas.Admin.Models.Teams;

namespace Spovest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamsController : Controller
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllTeamsRandomQuery();
            var teams = await _mediator.Send(query);
            var viewModel = new TeamsVM
            {
                Teams = teams
            };

            return View(viewModel);
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Add()
        {
            return View(new TeamFormVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Add(TeamFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new CreateTeamCommand
            {
                Name = model.Name,
                Img = model.Img
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetTeamByIdQuery(id);
            var team = await _mediator.Send(query);

            var model = new TeamFormVM
            {
                Id = team.Id,
                Name = team.Name,
                Img = team.Img
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(TeamFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new UpdateTeamCommand
            {
                Id = model.Id.Value,
                Name = model.Name,
                Img = model.Img
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Remove(int id)
        {
            var query = new GetTeamByIdQuery(id);
            var team = await _mediator.Send(query);

            var model = new TeamFormVM
            {
                Id = team.Id,
                Name = team.Name,
                Img = team.Img
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var command = new DeleteTeamCommand { Id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.Players.Query.GetAllPlayers;
using Spovest.Application.Features.Players.Query.GetPlayerById;
using Spovest.Application.Features.Players.Command.CreatePlayer;
using Spovest.Application.Features.Players.Command.UpdatePlayer;
using Spovest.Application.Features.Players.Command.DeletePlayer;
using Spovest.Areas.Admin.Models.Players;
using Spovest.Application.Features.Teams.Query.GetAllTeamsRandom;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Spovest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayersController : Controller
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllPlayersQuery();
            var players = await _mediator.Send(query);
            var playerVM = new PlayersVM
            {
                Players = players
            };

            return View(playerVM);
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Add()
        {
            try
            {
                var teamsQuery = new GetAllTeamsRandomQuery();
                var teams = await _mediator.Send(teamsQuery);

                var playerForm = new PlayerFormVM
                {
                    Teams = teams
                };
                return View(playerForm);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                ModelState.AddModelError("", "Ошибка при загрузке списка команд");
                return View(new PlayerFormVM()); 
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Add(PlayerFormVM model)
        {
            try
            {
                // Игнорируем валидацию для поля Teams, так как оно заполняется сервером.
                ModelState.Remove("Teams");

                // Всегда загружаем список команд
                var teamsQuery = new GetAllTeamsRandomQuery();
                var teams = await _mediator.Send(teamsQuery);
                
                model.Teams = teams;

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);
                    
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    
                    return View(model);
                }

                var command = new CreatePlayerCommand
                {
                    Name = model.Name,
                    TeamName = model.TeamName,
                    Games = model.Games,
                    Points = model.Points,
                    Assists = model.Assists,
                    Rebounds = model.Rebounds,
                    Steals = model.Steals,
                    Minutes = model.Minutes,
                    Ftps = model.Ftps
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                ModelState.AddModelError("", "Произошла ошибка при сохранении игрока");
                return View(model);
            }
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var query = new GetPlayerByIdQuery(id);
                var player = await _mediator.Send(query);

                var teamsQuery = new GetAllTeamsRandomQuery();
                var teams = await _mediator.Send(teamsQuery);

                var model = new PlayerSubFormVM
                {
                    Id = player.Id,
                    Name = player.Name,
                    TeamName = player.TeamName,
                    Games = player.Games ?? 0,
                    Points = player.Points ?? 0,
                    Assists = player.Assists ?? 0,
                    Rebounds = player.Rebounds ?? 0,
                    Steals = player.Steals ?? 0,
                    Minutes = player.Minutes ?? 0,
                    Ftps = player.Ftps ?? 0,
                    Teams = teams
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                ModelState.AddModelError("", "Произошла ошибка при загрузке данных игрока");
                
                // Создаем пустую модель с загруженными командами
                var teamsQuery = new GetAllTeamsRandomQuery();
                var teams = await _mediator.Send(teamsQuery);
                
                var model = new PlayerSubFormVM
                {
                    Teams = teams
                };
                
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(PlayerSubFormVM model)
        {
            try
            {
                // Игнорируем валидацию для поля Teams, так как оно заполняется сервером
                ModelState.Remove("Teams");

                // Всегда загружаем список команд
                var teamsQuery = new GetAllTeamsRandomQuery();
                var teams = await _mediator.Send(teamsQuery);
                model.Teams = teams;

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);
                    
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    
                    return View(model);
                }

                var command = new UpdatePlayerCommand
                {
                    Id = model.Id,
                    Name = model.Name,
                    TeamName = model.TeamName,
                    Games = model.Games ?? 0,
                    Points = model.Points ?? 0,
                    Assists = model.Assists ?? 0,
                    Rebounds = model.Rebounds ?? 0,
                    Steals = model.Steals ?? 0,
                    Minutes = model.Minutes ?? 0,
                    Ftps = model.Ftps ?? 0
                };

                var result = await _mediator.Send(command);
                if (result) return RedirectToAction(nameof(Index));
                
                ModelState.AddModelError("", "Не удалось обновить игрока");
                return View(model);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                ModelState.AddModelError("", "Произошла ошибка при обновлении игрока");
                
                // Загружаем список команд при исключении
                var teamsQuery = new GetAllTeamsRandomQuery();
                var teams = await _mediator.Send(teamsQuery);
                model.Teams = teams;
                
                return View(model);
            }
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Remove(int id)
        {
            var query = new GetPlayerByIdQuery(id);
            var player = await _mediator.Send(query);

            var model = new PlayerSubFormVM
            {
                Id = player.Id,
                Name = player.Name,
                TeamName = player.TeamName,
                Games = player.Games ?? 0,
                Points = player.Points ?? 0,
                Assists = player.Assists ?? 0,
                Rebounds = player.Rebounds ?? 0,
                Steals = player.Steals ?? 0,
                Minutes = player.Minutes ?? 0,
                Ftps = player.Ftps ?? 0
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var command = new DeletePlayerCommand { Id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
} 
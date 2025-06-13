using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.Users.Query.GetAllUsers;
using Spovest.Application.Features.Users.Query.GetUserById;
using Spovest.Areas.Admin.Models.Users;
using Spovest.Application.Features.Auth.Register;
using Spovest.Domain.Entities;
using Spovest.Application.Features.Users.Command.Add;
using Spovest.Application.Features.Users.Command.Delete;
using Microsoft.AspNetCore.Authorization;
using Spovest.Application.Features.Auth.RegisterOut;
using Spovest.Application.Features.Balance.Withdraw;

namespace Spovest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllUsersQuery();
            var tempUsers = await _mediator.Send(query);
            var users = tempUsers.Where(x => x.Name != "Admin" && x.Name != "Manager");
            var usersVM = new UsersVM
            {
                Users = users
            };

            return View(usersVM);
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Add()
        {
            return View(new UserFormVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Add(UserFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new RegisterOutCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            var model = new UserUpdateRemoveFormVM
            {
                Id = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Country = user.Country,
                Balance = user.Balance 
            };

            return View(model);
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Withdraw(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            var command = new WithdrawCommand
            {
                userId = user.UserId
            };

            var withdrawOK = await _mediator.Send(command);
            if (withdrawOK) { return RedirectToAction(nameof(Index)); }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> ToggleWithdrawBlock(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            var command = new UpdateUserCommand
            {
                Id = user.UserId,
                IsWithdrawBlocked = !user.IsWithdrawBlocked
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(UserUpdateRemoveFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new UpdateUserCommand
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Country = model.Country,
                Balance = model.Balance 
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Remove(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            var model = new UserFormVM
            {
                Id = user.UserId,
                FirstName = user.Name,
                Email = user.Email,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}

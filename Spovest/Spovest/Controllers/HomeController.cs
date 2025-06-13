using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.CurUser.GetCurrentAppUser;
using Spovest.Application.Features.Email.Command;
using Spovest.Application.Features.Users.Query.GetUserById;
using Spovest.Models;
using Spovest.Models.Home;

namespace Spovest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var homeVM = new BaseVM();

                var currentAppUserQuery = new GetCurrentAppUserQuery();
                var currentAppUser = await _mediator.Send(currentAppUserQuery);

                if (currentAppUser != null)
                {
                    try
                    {
                        var userQuery = new GetUserByIdQuery(currentAppUser.Id);
                        var userForVM = await _mediator.Send(userQuery);
                        if (userForVM != null)
                        {
                            homeVM.User = userForVM;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error getting user details");
                    }
                }

                return View(homeVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Index action");
                return View(new BaseVM());
            }
        }

        public async Task<IActionResult> About()
        {
            try
            {
                var homeVM = new BaseVM();

                var currentAppUserQuery = new GetCurrentAppUserQuery();
                var currentAppUser = await _mediator.Send(currentAppUserQuery);

                if (currentAppUser != null)
                {
                    try
                    {
                        var userQuery = new GetUserByIdQuery(currentAppUser.Id);
                        var userForVM = await _mediator.Send(userQuery);
                        if (userForVM != null)
                        {
                            homeVM.User = userForVM;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error getting user details");
                    }
                }

                return View(homeVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in About action");
                return View(new BaseVM());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            try
            {
                var emailVM = new BaseVM();

                var currentAppUserQuery = new GetCurrentAppUserQuery();
                var currentAppUser = await _mediator.Send(currentAppUserQuery);

                if (currentAppUser != null)
                {
                    try
                    {
                        var userQuery = new GetUserByIdQuery(currentAppUser.Id);
                        var userForVM = await _mediator.Send(userQuery);
                        if (userForVM != null)
                        {
                            emailVM.User = userForVM;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error getting user details");
                    }
                }

                return View(emailVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Contact action");
                return View(new BaseVM());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Contact(BaseVM emailVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(emailVM);
                }

                var command = new SendEmailCommand
                {
                    FullName = emailVM.FullName,
                    Email = emailVM.Email,
                    Subject = emailVM.Subject,
                    Body = emailVM.Body,
                };

                var emailSent = await _mediator.Send(command);

                if (emailSent) return Json(new { success = emailSent });

                ModelState.AddModelError(string.Empty, "A user with this email already exists.");
                return View(emailVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Contact post action");
                ModelState.AddModelError(string.Empty, "An error occurred while sending the email.");
                return View(emailVM);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

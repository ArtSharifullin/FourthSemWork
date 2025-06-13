using MediatR;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spovest.Models;
using Spovest.Models.Main;
using Spovest.Application.Features.Users.Query.GetUserById;
using Spovest.Application.Features.Teams.Query.GetAllTeamsRandom;
using Spovest.Application.Features.Players.Query.GetPlayerById;
using Spovest.Application.Features.Posts.Query.GetAllPostsByUserId;
using Spovest.Application.Features.Users.Query.GetAllUsers;
using Spovest.Application.Features.Players.Query.GetAllPlayers;
using Spovest.Application.Features.Price.Query.GetAllPrices;
using Spovest.Application.Features.CartItems.Query.GetAllCartItemsByUserId;
using Spovest.Application.Features.Transactions.Query.GetAllTransactionsByUserId;
using Spovest.Application.Features.Transactions.Query.GetAllTransactionsByUserIdAndType;
using Spovest.Application.Features.CurUser.GetCurrentIdentityUser;
using Spovest.Application.Features.CurUser.GetCurrentAppUser;
using Spovest.Application.Features.Cart.Buy;
using Spovest.Application.Features.Cart.Sell;
using Spovest.Application.Features.Balance.Refill;
using Spovest.Application.Features.Subscribtion.Query.GetAllFollowers;
using Spovest.Application.Features.Subscribtion.Query.GetAllFollowing;
using Spovest.Application.Features.Subscribtion.Command.Subscribe;
using Spovest.Application.Features.Subscribtion.Command.Unsubscribe;
using Spovest.Application.Features.Balance.Withdraw;

namespace Spovest.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;



        public MainController(
            ILogger<HomeController> logger, 
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        private async Task<IActionResult> CheckAuthorization()
        {
            var identityUserQuery = new GetCurrentIdentityUserQuery();
            var identityUser = await _mediator.Send(identityUserQuery);
            if (identityUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return null;
        }

        private async Task<MainViewModel> GetSubVM()
        {
            var currentAppUserQuery = new GetCurrentAppUserQuery();
            var currentAppUser = await _mediator.Send(currentAppUserQuery);

            if (currentAppUser == null)
            {
                return null;
            }

            var userQuery = new GetUserByIdQuery(currentAppUser.Id);
            var teamsQuery = new GetAllTeamsRandomQuery();
            var followersQuery = new GetAllFollowersQuery(currentAppUser.Id);
            var followingQuery = new GetAllFollowingQuery(currentAppUser.Id);


            var viewModel = new MainViewModel
            {
                User = await _mediator.Send(userQuery),
                CurrentUser = await _mediator.Send(userQuery),
                Teams = await _mediator.Send(teamsQuery),
                Balance = currentAppUser.Balance,
                CurrentFollowers = await _mediator.Send(followersQuery),
                CurrentFollowing = await _mediator.Send(followingQuery),
            };

            return viewModel;
        }


        public async Task<IActionResult> Profile(int page = 1)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            const int pageSize = 10;

            var cartItemsQuery = new GetAllCartItemsByUserIdQuery(subVM.User.UserId);
            var allCartItems = await _mediator.Send(cartItemsQuery);

            var pagedCartItems = allCartItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pricesQuery = new GetAllPricesQuery();
            var prices = await _mediator.Send(pricesQuery);

            var tranAllQuery = new GetAllTransactionsByUserIdQuery(subVM.User.UserId);
            var allTransactions = await _mediator.Send(tranAllQuery);

            var tranSellQuery = new GetAllTransactionsByUserIdAndTypeQuery(subVM.User.UserId, "sell");
            var sellTransactions = await _mediator.Send(tranSellQuery);

            var tranBuyQuery = new GetAllTransactionsByUserIdAndTypeQuery(subVM.User.UserId, "buy");
            var buyTransactions = await _mediator.Send(tranBuyQuery);

            subVM.CartItems = pagedCartItems;
            subVM.Prices = prices;
            subVM.Transactions_All = allTransactions;
            subVM.Transactions_Sell = sellTransactions;
            subVM.Transactions_Buy = buyTransactions;
            
            subVM.PageNumber = page;
            subVM.TotalPages = (int)Math.Ceiling(allCartItems.Count() / (double)pageSize);

            return View(subVM);
        }

        [HttpGet("Main/Blog/{id}")]
        public async Task<IActionResult> Blog(int id)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            var userQuery = new GetUserByIdQuery(id);
            var user = await _mediator.Send(userQuery);

            if (user == null)
            {
                return RedirectToAction("Users");
            }

            var postQuery = new GetAllPostsByUserIdQuery(id);
            var posts = await _mediator.Send(postQuery);

            var followersQuery = new GetAllFollowersQuery(user.UserId);
            var followers = await _mediator.Send(followersQuery);

            var followingQuery = new GetAllFollowingQuery(user.UserId);
            var following = await _mediator.Send(followingQuery);

            subVM.Posts = posts;
            subVM.User = user;
            subVM.Followers = followers;
            subVM.Following = following;

            return View(subVM);
        }

        [HttpGet("Main/Blog")]
        public async Task<IActionResult> Blog()
        {

            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            var postQuery = new GetAllPostsByUserIdQuery(subVM.User.UserId);
            var posts = await _mediator.Send(postQuery);

            subVM.Posts = posts;

            return View(subVM);
        }

        public async Task<IActionResult> Users(int page = 1, string search = null)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            const int pageSize = 10;
            var usersQuery = new GetAllUsersQuery();
            var tempUsers = await _mediator.Send(usersQuery);
            var allUsers = tempUsers.Where(x => x.Name != "Admin" && x.Name != "Manager");


            // Фильтрация по поиску
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                allUsers = allUsers.Where(u => 
                    u.Name.ToLower().Contains(search) || 
                    u.Country.ToLower().Contains(search)
                ).ToList();
            }

            // Пагинация
            var pagedUsers = allUsers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            subVM.Users = pagedUsers;
            subVM.PageNumber = page;
            subVM.TotalPages = (int)Math.Ceiling(allUsers.Count() / (double)pageSize);

            return View(subVM);
        }

        public async Task<IActionResult> Followers(int page = 1, string search = null)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            const int pageSize = 10;

            var usersQuery = new GetAllFollowersQuery(subVM.User.UserId);
            var allUsers = await _mediator.Send(usersQuery);

            // Фильтрация по поиску
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                allUsers = allUsers.Where(u =>
                    u.Name.ToLower().Contains(search) ||
                    u.Country.ToLower().Contains(search)
                ).ToList();
            }

            // Пагинация
            var pagedUsers = allUsers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            subVM.Users = pagedUsers;
            subVM.PageNumber = page;
            subVM.TotalPages = (int)Math.Ceiling(allUsers.Count() / (double)pageSize);

            return View("Users", subVM);
        }

        public async Task<IActionResult> NBA(int page = 1, string search = null)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            const int pageSize = 10;

            var playersQuery = new GetAllPlayersQuery();
            var allPlayers = await _mediator.Send(playersQuery);

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                allPlayers = allPlayers.Where(p => 
                    p.Name.ToLower().Contains(search) || 
                    p.TeamName.ToLower().Contains(search)
                ).ToList();
            }

            var pagedPlayers = allPlayers
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            var pricesQuery = new GetAllPricesQuery();    
            var prices = await _mediator.Send(pricesQuery);

            var cartItemsQuery = new GetAllCartItemsByUserIdQuery(subVM.User.UserId);
            var cartItems = await _mediator.Send(cartItemsQuery);

            subVM.Players = pagedPlayers;
            subVM.Prices = prices;
            subVM.CartItems = cartItems;

            subVM.PageNumber = page;
            subVM.TotalPages = (int)Math.Ceiling(allPlayers.Count() / (double)pageSize);

            return View(subVM);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int playerId, int quantity)
        {
            var currentAppUserQuery = new GetCurrentAppUserQuery();
            var user = await _mediator.Send(currentAppUserQuery);

            var operationCommand = new BuyCommand
            {
                userId = user.Id,
                PlayerId = playerId,
                Q = quantity
            };
            var boughtOK = await _mediator.Send(operationCommand);

            return Json(new { success = boughtOK });
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int playerId, int quantity)
        {
            var currentAppUserQuery = new GetCurrentAppUserQuery();
            var user = await _mediator.Send(currentAppUserQuery);

            var operationCommand = new SellCommand{
                userId = user.Id,
                PlayerId = playerId, 
                Q = quantity 
            };
            var soldOK = await _mediator.Send(operationCommand);

            return Json(new { success = soldOK });
        }

        public async Task<IActionResult> Subscribe(int id)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            if (id <= 0)
            {
                _logger.LogWarning($"Некорректный ID игрока: {id}");
                return RedirectToAction("Profile");
            }
            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            var subQuery = new SubscribeCommand{
                UserId = id,
                FollowerId = subVM.User.UserId
            };
            var ok = await _mediator.Send(subQuery);
            return Json(new { success = ok });
        }

        public async Task<IActionResult> Unsubscribe(int id)
        {
            var authResult = await CheckAuthorization();
            if (authResult != null) return authResult;

            if (id <= 0)
            {
                _logger.LogWarning($"Некорректный ID игрока: {id}");
                return RedirectToAction("Profile");
            }
            var subVM = await GetSubVM();
            if (subVM == null) return RedirectToAction("Login", "Auth");

            var subQuery = new UnsubscribeCommand
            {
                UserId = id,
                FollowerId = subVM.User.UserId
            };
            var ok = await _mediator.Send(subQuery);
            return Json(new { success = ok });
        }

        public async Task<IActionResult> Player(int id)
        {
            try
            {
                var authResult = await CheckAuthorization();
                if (authResult != null) return authResult;

                if (id <= 0)
                {
                    _logger.LogWarning($"Некорректный ID игрока: {id}");
                    return RedirectToAction("Profile");
                }

                var subVM = await GetSubVM();
                if (subVM == null) return RedirectToAction("Login", "Auth");

                var playerQuery = new GetPlayerByIdQuery(id);
                var player = await _mediator.Send(playerQuery);

                if (player == null)
                {
                    _logger.LogWarning($"Игрок с ID {id} не найден");
                    return RedirectToAction("Profile");
                }

                var pricesQuery = new GetAllPricesQuery();
                var prices = await _mediator.Send(pricesQuery);

                var cartItemsQuery = new GetAllCartItemsByUserIdQuery(subVM.User.UserId);
                var cartItems = await _mediator.Send(cartItemsQuery);

                subVM.Player = player;
                subVM.Prices = prices;
                subVM.CartItems = cartItems;

                return View(subVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при получении данных игрока: {ex.Message}");
                return RedirectToAction("Profile");
            }
        }

        public async Task<IActionResult> Balance()
        {
            try
            {
                var currentAppUserQuery = new GetCurrentAppUserQuery();
                var user = await _mediator.Send(currentAppUserQuery);

                var refillCommand = new RefillCommand
                {
                    userId = user.Id,
                };

                var refillOK = await _mediator.Send(refillCommand);
                return Json(new { success = refillOK, balance = user.Balance });
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении баланса пользователя");
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Withdraw()
        {
            var currentAppUserQuery = new GetCurrentAppUserQuery();
            var user = await _mediator.Send(currentAppUserQuery);

            if (user == null) 
            {
                return Json(new { success = false, message = "Пользователь не найден." });
            }

            if (user.IsWithdrawBlocked)
            {
                return Json(new { success = false, message = "Ваши денюшки пошли на покупку блёсен для Тагира) \nТак решил админ ;)" });
            }

            var command = new WithdrawCommand
            {
                userId = user.Id
            };

            var withdrawOK = await _mediator.Send(command);
            if (withdrawOK) {
                return Json(new { success = true, balance = user.Balance });
            } else {
                return Json(new { success = false, message = "Произошла ошибка при выводе средств. Возможно, недостаточно средств или другая проблема." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBalance()
        {
            try
            {
                var currentAppUserQuery = new GetCurrentAppUserQuery();
                var user = await _mediator.Send(currentAppUserQuery);
                return Json(new { success = true, balance = user.Balance });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении баланса пользователя");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserShares(int playerId)
        {
            try
            {
                var currentAppUserQuery = new GetCurrentAppUserQuery();
                var user = await _mediator.Send(currentAppUserQuery);

                var cartItemsQuery = new GetAllCartItemsByUserIdQuery(user.Id);
                var cartItems = await _mediator.Send(cartItemsQuery);

                var shares = cartItems.FirstOrDefault(c => c.PlayerId == playerId)?.Quantity ?? 0;

                return Json(new { success = true, shares = shares });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении количества акций");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

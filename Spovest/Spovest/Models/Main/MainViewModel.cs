using Spovest.Application.Features.Players.Query;
using Spovest.Application.Features.Teams.Query;
using Spovest.Application.Features.Users.Query;
using Spovest.Application.Features.Price.Query;
using Spovest.Application.Features.CartItems.Query;
using Spovest.Application.Features.Transactions.Query;
using Spovest.Application.Features.Posts.Query;

namespace Spovest.Models.Main
{
    public class MainViewModel
    {
        public UserDto User { get; set; }
        public UserDto CurrentUser { get; set; }
        public PlayersDto Player { get; set; }
        public IEnumerable<TeamsDto> Teams { get; set; }
        public IEnumerable<PostsDto> Posts { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<PlayersDto> Players { get; set; }
        public IEnumerable<PriceDto> Prices { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
        public IEnumerable<UserDto> CurrentFollowers { get; set; }
        public IEnumerable<UserDto> CurrentFollowing { get; set; }
        public IEnumerable<UserDto> Followers { get; set; }
        public IEnumerable<UserDto> Following { get; set; }
        public IEnumerable<TransactionDto> Transactions_All { get; set; }
        public IEnumerable<TransactionDto> Transactions_Sell { get; set; }
        public IEnumerable<TransactionDto> Transactions_Buy { get; set; }
        public decimal Balance { get; set; }


        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}


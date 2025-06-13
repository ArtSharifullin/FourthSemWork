using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Interfaces.Services;
using Spovest.Domain.Entities;
using Spovest.Domain.Entities.Enums;
using Spovest.Persistence.Contexts;

namespace Spovest.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBalanceService _balanceService;
        private readonly IPriceRepository _priceRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ICartItemRepository _cartItemRepository;


        public CartService(ApplicationDbContext context, 
            IBalanceService balanceService, 
            IPriceRepository priceRepository, 
            IPlayerRepository playerRepository, 
            ICartItemRepository cartItemRepository)
        {
            _context = context;
            _balanceService = balanceService;
            _priceRepository = priceRepository;
            _playerRepository = playerRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<bool> BuyAsync(int userId, int playerId, int q)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Id == userId);
            if (user == null) { return false; }
            var cartItems = await _cartItemRepository.GetAllCartItemsByUserIdAsync(user.Id);
            var player = await _playerRepository.GetPlayerByIdAsync(playerId);
            var actualPrice = await _priceRepository.GetActualPriceByPlayerIdAsync(playerId);
            var priceAtAdd = actualPrice.Purchase_price ?? 0;
            var totalCost = actualPrice.Purchase_price.GetValueOrDefault() * q;
            var boughtOk = await _balanceService.MinusAsync(user.Id, totalCost);
            if (boughtOk) 
            {
                var existingCartItem = cartItems.FirstOrDefault(x => x.PlayerId == playerId);

                if (existingCartItem == null)
                {
                    var cartItem = new CartItem
                    {
                        UserId = user.Id,
                        AppUser = user,
                        PlayerId = playerId,
                        Player = player,
                        Quantity = q,
                        PriceAtAdd = priceAtAdd,
                    };
                    _context.CartItems.Add(cartItem);
                }
                else
                {
                    existingCartItem.Quantity += q;
                    existingCartItem.PriceAtAdd = priceAtAdd;
                    _context.CartItems.Update(existingCartItem);
                }
                _context.Transactions.Add(new Transaction
                {
                    UserId = user.Id,
                    OperationType = OperationType.Buy,
                    Cost = totalCost,
                    CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                });
                _context.SaveChanges();
            }
            return boughtOk;
        }

        public async Task<bool> SellAsync(int userId, int playerId, int q)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Id == userId);
            if (user == null) { return false; }
            var cartItems = await _cartItemRepository.GetAllCartItemsByUserIdAsync(user.Id);
            var existingCartItem = cartItems.FirstOrDefault(x => x.PlayerId == playerId);

            if (existingCartItem == null) { return false; }

            var actualPrice = await _priceRepository.GetActualPriceByPlayerIdAsync(playerId);
            var totalCost = actualPrice.Sale_price.GetValueOrDefault() * q;

            var sellOk = await _balanceService.PlusAsync(user.Id, totalCost);
            if (sellOk)
            {
                if (existingCartItem.Quantity - q > 0)
                {
                    existingCartItem.Quantity -= q;
                    _context.CartItems.Update(existingCartItem);
                }
                else
                {
                    _context.CartItems.Remove(existingCartItem);
                }

            }
            _context.Transactions.Add(new Transaction
            {
                UserId = user.Id,
                OperationType = OperationType.Sell,
                Cost = totalCost,
                CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            });
            _context.SaveChanges();
            return sellOk;
        }
    }
}

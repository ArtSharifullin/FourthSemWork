using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spovest.Domain.Entities;
using Spovest.Application.Interfaces.Hubs;
using Spovest.Persistence.Contexts;
using Spovest.Infrastructure.Hubs;

namespace Spovest.Infrastructure.Services
{
    public class PriceUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Random _random;
        private readonly ILogger<PriceUpdateService> _logger;
        private const int MAX_RECORDS_PER_PLAYER = 3;
        private const int PLAYERS_COUNT = 30;

        public PriceUpdateService(
            IServiceProvider serviceProvider,
            ILogger<PriceUpdateService> logger)
        {
            _serviceProvider = serviceProvider;
            _random = new Random();
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<PriceHub, IPriceHub>>();

                        // Начинаем транзакцию
                        using var transaction = await context.Database.BeginTransactionAsync(stoppingToken);
                        try
                        {
                            _logger.LogInformation("Начало обновления цен");

                            // Получаем количество записей для каждого игрока
                            var recordCounts = await context.Prices
                                .GroupBy(p => p.PlayerId)
                                .Select(g => new { PlayerId = g.Key, Count = g.Count() })
                                .ToDictionaryAsync(x => x.PlayerId, x => x.Count, stoppingToken);

                            // Получаем последние цены для каждого игрока
                            var latestPrices = await context.Prices
                                .GroupBy(p => p.PlayerId)
                                .Select(g => new
                                {
                                    PlayerId = g.Key,
                                    LatestPrice = g.OrderByDescending(p => p.Timestamp)
                                        .Select(p => new
                                        {
                                            PurchasePrice = p.Purchase_price ?? 0,
                                            SalePrice = p.Sale_price ?? 0
                                        })
                                        .FirstOrDefault()
                                })
                                .ToDictionaryAsync(x => x.PlayerId, x => x.LatestPrice, stoppingToken);

                            _logger.LogInformation($"Получены текущие цены для {latestPrices.Count} игроков");

                            var currentTime = DateTime.UtcNow;
                            var newPrices = new List<PriceHistory>();
                            var last30 = await context.Prices.Skip(Math.Max(0, context.Prices.Count() - 30)).ToListAsync();

                            // Для каждого игрока
                            for (int playerId = 1; playerId <= PLAYERS_COUNT; playerId++)
                            {
                                // Если у игрока больше MAX_RECORDS_PER_PLAYER записей, удаляем старые
                                if (recordCounts.TryGetValue(playerId, out int count) && count >= MAX_RECORDS_PER_PLAYER)
                                {
                                    var oldestPrices = await context.Prices
                                        .Where(p => p.PlayerId == playerId)
                                        .OrderBy(p => p.Timestamp)
                                        .Take(count - MAX_RECORDS_PER_PLAYER + 1)
                                        .ToListAsync(stoppingToken);

                                    context.Prices.RemoveRange(oldestPrices);
                                    _logger.LogInformation($"Удалено {oldestPrices.Count} старых записей для игрока {playerId}");
                                }

                                var currentPrice = latestPrices.GetValueOrDefault(playerId)?.PurchasePrice > 0 
                                    ? latestPrices[playerId] 
                                    : null;

                                var priceHistory = new PriceHistory
                                {
                                    PlayerId = playerId,
                                    Timestamp = currentTime
                                };

                                if (currentPrice == null)
                                {
                                    priceHistory.Purchase_price = 10;
                                    priceHistory.Sale_price = 10;
                                    _logger.LogInformation($"Установлена начальная цена для игрока {playerId}");
                                }
                                else
                                {
                                    // Увеличиваем диапазон изменения цены до ±25%
                                    var priceChangePercent = (_random.NextDouble() * 50) - 25; // от -25% до +25%
                                    var newPPrice = Math.Max(0.01M, (decimal)(currentPrice.PurchasePrice * (1 + (decimal)priceChangePercent / 100)));
                                    var newSPrice = Math.Max(0.01M, (decimal)(currentPrice.SalePrice * (1 + (decimal)priceChangePercent / 100)));

                                    priceHistory.Purchase_price = Math.Round(newPPrice, 2);
                                    priceHistory.Sale_price = Math.Round(newSPrice, 2);
                                    
                                    _logger.LogInformation($"Обновлены цены для игрока {playerId}: Purchase={priceHistory.Purchase_price} (изменение {priceChangePercent:F2}%), Sale={priceHistory.Sale_price}");
                                }

                                newPrices.Add(priceHistory);
                            }

                            // Добавляем новые записи в базу данных
                            await context.Prices.AddRangeAsync(newPrices, stoppingToken);
                            await context.SaveChangesAsync(stoppingToken);
                            _logger.LogInformation($"Сохранено {newPrices.Count} новых записей в базу данных");

                            // Фиксируем транзакцию
                            await transaction.CommitAsync(stoppingToken);

                            // Отправляем обновления через SignalR
                            await hubContext.Clients.All.ReceivePriceUpdates(newPrices,last30);
                            _logger.LogInformation("Обновления отправлены клиентам через SignalR");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Ошибка при выполнении транзакции");
                            await transaction.RollbackAsync(stoppingToken);
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка при обновлении цен");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
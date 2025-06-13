using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface IPriceRepository
    {
        Task<IEnumerable<PriceHistory>> GetAllPricesByPlayerIdAsync(int id);
        Task<IEnumerable<PriceHistory>> GetAllPricesAsync();
        Task<PriceHistory> GetActualPriceByPlayerIdAsync(int id);
        Task<PriceHistory> GetPriceByIdAsync(int id);

        Task<bool> CreatePriceAsync(int playerId, decimal pprice, decimal sprice);
        Task<bool> DeletePriceAsync(int id);
        Task<bool> UpdatePriceAsync(int id, int playerId, decimal pprice, decimal sprice);


    }
}

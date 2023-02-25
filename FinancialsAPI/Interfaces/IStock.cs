using FinancialsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Interfaces
{
    public interface IStock
    {
        Task<IEnumerable<Stock>> GetStocksAsync();
        void AddStock(Stock stock);
        void DeleteStock(int stockId);
    }
}

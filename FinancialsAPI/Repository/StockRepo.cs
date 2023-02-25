using FinancialsAPI.Data;
using FinancialsAPI.Interfaces;
using FinancialsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Repository
{
    public class StockRepo : IStock
    {
        private readonly DataContext context;

        public StockRepo(DataContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Stock>> GetStocksAsync()
        {
            return await context.Stocks.ToListAsync();
        }

        public void AddStock(Stock stock)
        {
            context.Stocks.Add(stock);
        }

        public void DeleteStock(int stockId)
        {
            var stock = context.Stocks.Find(stockId);
            context.Stocks.Remove(stock);
        }
    }
}

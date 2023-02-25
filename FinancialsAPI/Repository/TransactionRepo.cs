using FinancialsAPI.Data;
using FinancialsAPI.Models;
using FinancialsAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Repository
{
    public class TransactionRepo : ITransaction
    {
        private readonly DataContext context;

        public TransactionRepo(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await context.Transactions.ToListAsync();
        }

        public void AddTransaction(Transaction transaction)
        { 
            context.Transactions.Add(transaction);
        }

        public void DeleteTransaction(int transactionId)
        {
            var transaction = context.Transactions.Find(transactionId);
            context.Transactions.Remove(transaction);
        }
    }
}

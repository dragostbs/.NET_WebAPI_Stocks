using FinancialsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Interfaces
{
    public interface ITransaction
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinancialsAPI.Models;
using FinancialsAPI.Interfaces;
using AutoMapper;
using FinancialsAPI.DTO;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FinancialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public TransactionsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTransactions()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transactions = await uow.Transaction.GetTransactionsAsync(userId);
            return Ok(transactions);
        }

        // POST
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTransaction(TransactionDto transactionDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var stock = new Stock
            {
                Symbol = transactionDto.Symbol,
                Price = transactionDto.Price
            };
            uow.Stock.AddStock(stock);
            await uow.SaveAsync();

            var transaction = new Transaction
            {
                Result = transactionDto.Result,
                Date = transactionDto.Date,
                StockId = stock.Id,
                UserId = userId.ToString(), 
            };

            uow.Transaction.AddTransaction(transaction);
            await uow.SaveAsync();
            return Ok(transaction);
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            uow.Transaction.DeleteTransaction(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}

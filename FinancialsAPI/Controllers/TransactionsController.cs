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

namespace FinancialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public TransactionsController(IUnitOfWork uow, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.uow = uow;
            this.mapper = mapper;
            _userManager = userManager;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await uow.Transaction.GetTransactionsAsync();
            return Ok(transactions);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AddTransaction(TransactionDto transactionDto)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

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
                UserId = user?.ToString(), // "90bbb102-e730-4fd3-8f19-4dd5320895ce"
            };

            uow.Transaction.AddTransaction(transaction);
            await uow.SaveAsync();
            return Ok(transaction);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            uow.Transaction.DeleteTransaction(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}

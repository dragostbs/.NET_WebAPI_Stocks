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
        private readonly UserManager<IdentityUser> _userManager;

        public TransactionsController(IUnitOfWork uow, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.uow = uow;
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
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            /*var user = await _userManager.GetUserAsync(User);
            var transaction = new Transaction
            {
                Result = transactionDto.Result,
                UserId = user.Id
            };*/

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

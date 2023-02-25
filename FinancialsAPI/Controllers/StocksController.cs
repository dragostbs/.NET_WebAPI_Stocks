using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialsAPI.Data;
using FinancialsAPI.Models;
using FinancialsAPI.Interfaces;
using AutoMapper;
using FinancialsAPI.DTO;

namespace FinancialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public StocksController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await uow.Stock.GetStocksAsync();
            return Ok(stocks);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            uow.Stock.AddStock(stock);
            await uow.SaveAsync();
            return Ok(stock);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            uow.Stock.DeleteStock(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinancialsAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        // public DbSet<UserLogin> UserLogin { get; set; }
    }
}

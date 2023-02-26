using FinancialsAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public string Symbol { get; set; }

        public float Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string Symbol { get; set; } = string.Empty;

        public float Price { get; set; }
    }
}

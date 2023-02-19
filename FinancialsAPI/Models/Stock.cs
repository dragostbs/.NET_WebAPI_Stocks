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

        [Required]
        [StringLength(10)]
        public string Symbol { get; set; } 

        [Required]
        public float Price { get; set; } 
    }
}

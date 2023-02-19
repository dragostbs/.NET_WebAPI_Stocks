using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Result { get; set; }

        public DateTime Date { get; set; } 

        public int StockId { get; set; }

       // public int UserId { get; set; }

        #nullable enable

        public Stock? Stock { get; set; }

       // public UserLogin? User { get; set; }
    }
}

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
        [StringLength(5)]
        public string Result { get; set; } 

        public DateTime Date { get; set; }

        public int StockId { get; set; }

        #nullable enable

        public Stock? Stock { get; set; }
    }
}

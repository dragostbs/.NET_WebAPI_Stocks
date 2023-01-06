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

        [StringLength(5)]
        public string Result { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public int StockId { get; set; }

        #nullable enable
        public User? User { get; set; }

        public Stock? Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Username { get; set; } = string.Empty;
    }
}

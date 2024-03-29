﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Username { get; set; } 

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}

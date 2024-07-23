using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication35.Models.viewModel
{
    public class LoginViewModel
    {
        public int Userid { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
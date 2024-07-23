using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication35.Models.viewModel
{
    public class Reg_CustViewModel
    {
        public int Userid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayName("email")]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string phoneno { get; set; }
        [Required]
        public string password { get; set; }
        [System.Web.Mvc.Compare("password", ErrorMessage = "passwordMismatch")]
        
        public  string retypepassword { get; set; }


    }
}
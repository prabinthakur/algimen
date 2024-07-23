using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication35.Models.viewModel
{
    public class hiredriverviewmodel
    {

        public int hireid { get; set; }
        public string drivertype { get; set; }
        public int customerid { get; set; }
        [Required]
        public DateTime hiredate { get; set; }
        [Required]
        public Decimal salary { get; set; }
        public int driverid { get; set; }
    }
}
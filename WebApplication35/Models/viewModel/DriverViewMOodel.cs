using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication35.Models.viewModel
{
    public class DriverViewMOodel
    {

        public int driverid { get; set; }
        [Required]
        public string drivername { get; set; }
        public string type { get; set; }
        [Required]
        public decimal salary { get; set; }
        [Required]
        public int experience { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication35.Models.viewModel
{
    public class vehicleViewModel
    {

        public int vehicleid { get; set; }

        public string vehicletype { get; set; }
        public Nullable<int> vehicleNumber { get; set; }
        [Required]
        public Nullable<decimal> vehiclePrice { get; set; }
        public string photo { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication35.Models.viewModel
{
    public class staffViewModell
    {
        public int staffid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string post { get; set;}
        public Nullable<decimal> salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }
}
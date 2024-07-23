using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication35.Models.viewModel
{
    public class bookcabViewModel
    {
        public int bookid { get; set; }
       
        public string username { get; set; }
        public DateTime bookdate { get; set; }
        public int confirmationid { get; set; }
        public string confirmation { get; set; }
        [Required]
        public string pickup { get; set; }
        [Required]
        public string drop { get; set; }


    }
}
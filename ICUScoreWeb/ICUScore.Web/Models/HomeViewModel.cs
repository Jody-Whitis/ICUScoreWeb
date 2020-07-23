using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class HomeViewModel
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
        public Login Login { get; set; }

    }
}
using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class HomeViewModel
    {
        public string User { get; set; }
        public string Password { get; set; }
        public Login Login { get; set; }

    }
}
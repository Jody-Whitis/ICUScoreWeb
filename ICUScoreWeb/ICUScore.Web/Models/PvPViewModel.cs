﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class PvPViewModel
    {
        public string WinnerName { get; set; }
        public string OpponentName { get; set; }
         public DateTime lastPlayedDate { get; set; }
    }
}
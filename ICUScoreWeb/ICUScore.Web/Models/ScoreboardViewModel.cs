using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class ScoreboardViewModel
    {
        public string PlayerName { get; set; }
        public double Highscore { get; set; }
        public DateTime lastScored { get; set; }
        public int PlayerID { get; set; }
        public int gID { get; set; }
        public int pID { get; set; }
        public String GameMode { get; set; }

    }
}
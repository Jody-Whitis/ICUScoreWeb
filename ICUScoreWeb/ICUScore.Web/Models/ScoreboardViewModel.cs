using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class ScoreboardViewModel
    {
        public IEnumerable<HighScore> highScores { get; set; }
 
        public int PlayerID { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Models
{
    public class HighScore
    {
        public int ID { get; set; }
        public int pID { get; set; }
        public int gID { get; set; }
        public double Highscore { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime? LastEmailed { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
 
namespace ICUScore.Data.Models
{
    public class PvP
    {
        public int ID { get; set; }
        public int pID { get; set; }
        public int opponentID { get; set; }
        public string LastWinner { get; set; }
        public int gID { get; set; }
        public DateTime LastMatch { get; set; }
        public int Win { get; set; }
     }
}

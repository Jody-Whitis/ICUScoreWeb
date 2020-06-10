using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{
    public class InMemoryPvPTable
    {
        List<PvP> pvp;
        public InMemoryPvPTable()
        {
            pvp = new List<PvP> { new PvP {ID=1 , pID = 1,opponentID=2,LastWinner="Jody",LastMatch = DateTime.Now,Win=2} };
        }
    }
}

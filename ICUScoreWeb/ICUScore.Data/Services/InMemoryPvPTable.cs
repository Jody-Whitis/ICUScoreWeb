using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlTypes;
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
            pvp = new List<PvP> { new PvP {ID=1 , pID = 1,oID = 99,OpponentName="Test",LastWinner="Jody",LastMatch = DateTime.Now} };
        }

        public IEnumerable<PvP> GetAll()
        {
            return pvp.OrderBy(r => r.LastMatch);
        }

        public PvP SelectPvP(PvP existingPvP)
        {
            PvP pvpRecord = new PvP();
            pvpRecord = pvp.Where(p => p.pID == existingPvP.pID && p.oID == existingPvP.oID).FirstOrDefault();
            return pvpRecord;
        }

        public void UpdatePvP(PvP newPvP)
        {
            PvP existingPvP = pvp.Where(p => p.pID == newPvP.pID && p.oID == newPvP.oID).FirstOrDefault();
            int currentWins = existingPvP.Win;
            existingPvP.OpponentName = newPvP.OpponentName;
            existingPvP.Win = currentWins++;
            existingPvP.LastMatch = DateTime.Now;
        }

        public void AddPvP(PvP newPvP)
        {
            pvp.Add(newPvP);
            newPvP.ID = pvp.Max(p => p.ID) + 1;

        }
    }
}

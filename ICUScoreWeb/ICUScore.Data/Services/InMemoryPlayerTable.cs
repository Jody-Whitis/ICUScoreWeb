using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{
    public class InMemoryPlayerTable
    {
        List<Player> players;
        public InMemoryPlayerTable()
        {
            players = new List<Player> { new Player {ID = 1,Name = "Jody", Registered=1,RegistrationDate=DateTime.Today,Wins=20},
            new Player{ID=2,Name = "Scruff", Registered = 0, RegistrationDate = null}            
            };
        }
            
        public void AddNewPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
            newPlayer.ID = players.Max(p => p.ID) + 1;
        }

        public void EditPlayer(int id,string name)
        {
            Player selectedPlayer = players.Where(p => p.ID == id).FirstOrDefault();
            selectedPlayer.Name = name;
        }

         public IEnumerable<Player> GetAll()
        {
            return players.OrderBy(r => r.Name);
        }

        public IEnumerable<Player> GetAllRegistered(Boolean isRegistered)
        {
            int isRegisteredBit = Convert.ToInt32(isRegistered);
            return players.Where(p => p.Registered == isRegisteredBit);
        }

        public void RegisterPlayer(int id)
        {
            Player registerPlayer = players.Where(p => p.ID == id).FirstOrDefault();
            registerPlayer.Registered = 1;
            registerPlayer.RegistrationDate = DateTime.Now;
        }

        public void UnRegisterPlayer(int id)
        {
            Player unregisteredPlayer = players.Where(p => p.ID == id).FirstOrDefault();
            unregisteredPlayer.Registered = 0;
            unregisteredPlayer.RegistrationDate = null;
        }

     //Update wins or add new one;
    }
}

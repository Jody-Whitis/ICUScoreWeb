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
            



    }
}

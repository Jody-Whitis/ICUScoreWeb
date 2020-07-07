using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{
    public class InMemoryGamesTable
    {
        List<Game> games;
        public InMemoryGamesTable()
        {
            games = new List<Game> { new Game { ID=0,Name="Pacman"}, new Game { ID = 1, Name = "DK" }, new Game { ID = 2, Name = "Pool" } ,
            new Game { ID=3,Name="PvP"},new Game { ID=4,Name="SA2"},new Game { ID=5,Name="test"}
            };
        }

        public IEnumerable<Game> GetAll()
        {
            return games.OrderBy(g => g.ID);
        }
    }
}

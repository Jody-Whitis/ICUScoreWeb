using ICUScore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICUScore.Web.Models
{
    public class PvPViewModel
    {
         public string WinnerName { get; set; }
         public String OpponentName { get; set; }
         public DateTime lastPlayedDate { get; set; }
         public int gID { get; set; }
         public int pID { get; set; }
        public string GameName { get; set; }
        public IEnumerable<Player> listOfPlayers {get;set;}
        public IEnumerable<Game> listOfGames { get; set; }
     }
}
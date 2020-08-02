using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class LoginViewModel
    {
        public string User { get; set; }
        public Login login { get; set; }
        public int Id { get; set; }        
        public int PId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Player> listOfPlayers { get; set; }
    }
}
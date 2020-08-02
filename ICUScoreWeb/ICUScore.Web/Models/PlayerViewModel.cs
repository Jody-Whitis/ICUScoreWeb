using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICUScore.Web.Models
{
    public class PlayerViewModel
    {
        [Required]
        public string Name { get; set; }

        public Player player { get; set; }

        [Required]
        public int Id { get; set; }

        public IEnumerable<Player> listOfPlayers { get; set; }
    }
}
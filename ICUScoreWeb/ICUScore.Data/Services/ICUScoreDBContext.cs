using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ICUScore.Data.Models;

namespace ICUScore.Data.Services
{
    public class ICUScoreDBContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Registered { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}

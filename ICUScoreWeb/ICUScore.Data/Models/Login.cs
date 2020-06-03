using ICUScore.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Models
{
    public class Login
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int Subscribed { get; set; }
        public DateTime LastLogin { get; set; }
        public string LastLoginDevice { get; set; }
        public DateTime LastPasswordUpdate { get; set; }
        public int pID { get; set; }
        public Permissions permissions { get; set; }
        public int TwoFactorEnabled { get; set; }
        public string TempPassword { get; set; }
        public int Locked { get; set; }
    }
}

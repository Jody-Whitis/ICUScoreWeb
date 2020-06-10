using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{
    public class InMemoryLoginTable
    {
        List<Login> logins;
        public InMemoryLoginTable()
        {
            logins = new List<Login> { new Login { ID=1,EmailAddress="jodywhitis0407@gmail.com",Password="test",Subscribed=1,LastLogin=DateTime.Today,LastLoginDevice="JPC",LastPasswordUpdate=DateTime.Today,pID=1},
            };
        }

    }
}

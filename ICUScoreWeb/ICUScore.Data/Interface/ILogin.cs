using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Interface
{
    public interface ILogin
    {
        Boolean GetLogin();
        Boolean UpdatePassword();
    }
}

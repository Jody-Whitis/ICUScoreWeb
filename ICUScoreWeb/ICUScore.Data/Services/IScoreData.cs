using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{
    public interface IScoreData
    {
         IEnumerable<Object> GetAll();
    }
}

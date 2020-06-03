using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Models
{
    public enum AppState
    {
        ExceptionError = -1,
        Start = 0,
        Register = 1,
        SelectPlayer = 2,
        Winner = 3,
        Switch = 4,
        Add = 5,
        Edit = 6,
        Delete = 7
    }
}

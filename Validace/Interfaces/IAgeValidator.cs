using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validace.Interfaces
{
    interface IAgeValidator
    {
        bool IsOkay(string a, out int giveBack);
    }
}

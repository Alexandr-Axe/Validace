using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validace.Interfaces;

namespace Validace.Validators
{
    class DateValidator : IDateValidator
    {
        public bool IsOkay(DateTime dt) 
        {
            if (dt == null) return false;
            else if (dt.Year == 2021) return false;
            return true;
        }
    }
}

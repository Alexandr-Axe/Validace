using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validace.Interfaces;

namespace Validace.Validators
{
    class AgeValidator : IAgeValidator
    {
        public bool IsOkay(string a, out int giveBack) 
        {
            giveBack = int.MinValue; //zabránění pádu kódu
            if (int.TryParse(a, out int i) == false) return false; //pokud nezadáme číslo, nic se nestane
            if (i > 0 && i < 150) //rozsah věku
            {
                giveBack = i;
                return true;
            }
            return false;
        }
    }
}

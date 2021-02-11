using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validace.Interfaces;

namespace Validace.Validators
{
    class PINValidator : IPINValidator
    {
        string[] RozdelenyPIN;
        string p;
        int i;
        //RozdelenyPIN[0] = rok
        //RozdelenyPIN[1] = rok
        //RozdelenyPIN[2] = měsíc
        //RozdelenyPIN[3] = měsíc
        //RozdelenyPIN[4] = den
        //RozdelenyPIN[5] = den
        public bool IsOkay(string a) 
        {
            if (!a.Contains("/")) return false;
            RozdelenyPIN = a.Split('/');
            if (RozdelenyPIN[0].Length != 6) return false;
            else if (RozdelenyPIN[1].Length < 3) return false;
            char[] RokMesicDen = RozdelenyPIN[0].ToCharArray();
            foreach (char Item in RokMesicDen)
            {
                if (!Char.IsDigit(Item)) return false;
            }
            if (RokMesicDen[0] == 0) p = RokMesicDen[1].ToString();
            else p = $"{RokMesicDen[0]}{RokMesicDen[1]}";
            i = Int32.Parse(p);
            if (i > 54 && RozdelenyPIN[1].Length == 3) return false;
            else if (i < 54 && RozdelenyPIN[1].Length == 4) return false;
            if (RokMesicDen[2] != 0 || RokMesicDen[2] != 1 || RokMesicDen[2] != 5 || RokMesicDen[2] != 6) return false;
            if (i > 53 && RozdelenyPIN[1].Length == 4) return true;
            else if (i < 54 && RozdelenyPIN[1].Length == 3) return true;
            return false;
        }
    }
}

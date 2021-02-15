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
        //RokMesicDen[0] = rok
        //RokMesicDen[1] = rok
        //RokMesicDen[2] = měsíc
        //RokMesicDen[3] = měsíc
        //RokMesicDen[4] = den
        //RokMesicDen[5] = den
        //                        012345/0123
        //                        020103/0027
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
            foreach (char Item in RozdelenyPIN[1])
            {
                if (!Char.IsDigit(Item)) return false;
            }
            if (RokMesicDen[0] == '3' || RokMesicDen[0] == '4' || (RokMesicDen[0] == '5' && RokMesicDen[1] == '3'))
            {
                if (RozdelenyPIN[1].Length != 3) return false;
            }
            else if ((RokMesicDen[0] == '5' && RokMesicDen[1] == '4') || RokMesicDen[0] == '6' || RokMesicDen[0] == '7' || RokMesicDen[0] == '8' || RokMesicDen[0] == '9' || RokMesicDen[0] == '0' || RokMesicDen[0] == '1' || RokMesicDen[0] == '2')
            {
                if (RozdelenyPIN[1].Length != 4) return false;
            }
            if (RokMesicDen[2] == '0' || RokMesicDen[2] == '1' || RokMesicDen[2] == '5' || RokMesicDen[2] == '6') return true;
            return false;
        }
    }
}

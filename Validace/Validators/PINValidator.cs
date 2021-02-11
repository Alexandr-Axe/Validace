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
            try
            {
                Convert.ToInt32(RozdelenyPIN[0]);
                Convert.ToInt32(RozdelenyPIN[1]);
                Convert.ToInt32(RozdelenyPIN[2]);
                Convert.ToInt32(RozdelenyPIN[3]);
                Convert.ToInt32(RozdelenyPIN[4]);
                Convert.ToInt32(RozdelenyPIN[5]);
            }
            catch (Exception)
            {
                return false;
            }
            if (RozdelenyPIN[0].Length != 6) return false;
            else if (RozdelenyPIN[1].Length != 3 || RozdelenyPIN[1].Length != 4) return false;
            char[] RokMesicDen = RozdelenyPIN[0].ToCharArray();
            if (RokMesicDen[0] == 0) p = RokMesicDen[1].ToString();
            else p = $"{RokMesicDen[0]}{RokMesicDen[1]}";
            i = Convert.ToInt32(p);
            if (i > 54 && RozdelenyPIN[1].Length == 3) return false;
            else if (i < 54 && RozdelenyPIN[1].Length == 4) return false;
            if (Convert.ToInt32(RozdelenyPIN[2]) != 0 || Convert.ToInt32(RozdelenyPIN[2]) != 1 || Convert.ToInt32(RozdelenyPIN[2]) != 5 || Convert.ToInt32(RozdelenyPIN[2]) != 6) return false;
            if (i > 53 && RozdelenyPIN[1].Length == 4) return true;
            else if (i < 54 && RozdelenyPIN[1].Length == 3) return true;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validace.Interfaces;

namespace Validace.Validators
{
    class NameValidator : INameValidator
    {
        public bool IsOkay(string a)
        {
            if (a.Length > 3 && a.Length < 58) return true; //Oto a Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch (název města ve Velke Británii, ale co)
            else return false;
        }
    }
}

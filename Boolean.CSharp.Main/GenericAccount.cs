using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class GenericAccount : Account
    {
        public GenericAccount(string ID, BankBranch bank) : base(ID, bank) 
        { }

    }
}

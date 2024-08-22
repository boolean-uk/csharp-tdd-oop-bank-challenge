using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : Account
    {

        public SavingsAccount(int id, string type, string owner)
        {
            ID = id;
            Type = type;
            Owner = owner;
        }
    }
}

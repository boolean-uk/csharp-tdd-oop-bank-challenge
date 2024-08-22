using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {

        public CurrentAccount(int id, string type, string owner)
        {
            this.ID = ID;
            this.Type = type;
            this.Owner = owner;
        }
    }
}

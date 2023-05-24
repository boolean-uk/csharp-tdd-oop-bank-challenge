using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccounts
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(IUser user) : base(user)
        {

        }
    }
}

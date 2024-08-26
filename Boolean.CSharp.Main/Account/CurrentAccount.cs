using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Account
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(BankBranches b, int accountid, string accountname, Customer c) : base(b, accountid, accountname, c)
        {

        }


    }
}

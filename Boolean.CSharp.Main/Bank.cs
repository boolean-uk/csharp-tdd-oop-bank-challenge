using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {

        private List<IAccount> _accounts = new List<IAccount>();
        public bool AddAccount(string user, string bankType)
        {

            if (bankType == "current")
            {
               _accounts.Add(new CurrentAccount(_accounts.Count(), bankType, user));
                return true;
            }
            if (bankType == "savings")
            {
                _accounts.Add(new SavingsAccount(_accounts.Count(), bankType, user));
                return true;
            }
            
            return false;
        }
    }
}

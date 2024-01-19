using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private List<IAccount> _accounts = [];
        public void CreateAccount(string name, AccountType type)
        {
            switch (type)
            {
                case (AccountType.Current):
                    _accounts.Add(new CurrentAccount(name));
                    break;
                case AccountType.Savings:
                    _accounts.Add(new SavingsAccount(name));
                    break;
            }
        }

        public List<IAccount> GetAccounts()
        {
            return _accounts;
        }

        public int GetNumberOfAccounts()
        {
            return _accounts.Count;
        }
    }
}

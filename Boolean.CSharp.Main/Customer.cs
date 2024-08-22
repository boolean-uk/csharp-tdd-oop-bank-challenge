using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public List<IAccount> accounts {  get; set; }  = new List<IAccount>();

        public bool CreateAccount(AccountType type)
        {
            IAccount? account = null; 

            switch (type)
            {
                case AccountType.Current:
                    account = new CurrentAccount();
                    break;

                case AccountType.Savings:
                    account = new SavingsAccount();
                    break;
            }

            if (account == null)
                return false;

            accounts.Add(account);
            return true;
        }
    }
}

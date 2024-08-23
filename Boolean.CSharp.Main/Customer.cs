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

        public bool CreateAccount(AccountType type, Branch branch)
        {
            IAccount? account = null; 

            switch (type)
            {
                case AccountType.Current:
                    account = new CurrentAccount(branch);
                    break;

                case AccountType.Savings:
                    account = new SavingsAccount(branch);
                    break;
            }

            if (account == null)
                return false;

            accounts.Add(account);
            return true;
        }

        //Apply for an arranged overdraft (assume bank decides overdraft limit)
        public void RequestOverdraft(IAccount account)
        {
            account.OverdraftRequestIsActive = true;
        }
    }
}

using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Customer
    {
        public CurrentAccount _currentAccount;
        public SavingsAccount _savingsAccount;
        public Customer() { }


        public CurrentAccount CreateCurrentAccount(string AccountName, Enums.AccountBranch branch)
        {
            CurrentAccount account = new CurrentAccount(AccountName, branch);
            _currentAccount = account;
            return account;
        }

        public SavingsAccount CreateSavingsAccount(string AccountName, Enums.AccountBranch branch)
        {
            SavingsAccount account = new SavingsAccount(AccountName, branch);
            _savingsAccount = account;
            return account;
        }

        public void requestOverdraft(Account account)
        {
            account.RequestOverdraft();
        }

        public void CheckOverDraft(Account account)
        {
            Console.WriteLine(account.GetOverdraftStatus());
        }
    }
}

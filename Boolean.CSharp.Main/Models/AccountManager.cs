using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models
{
    public class AccountManager
    {
        public Dictionary<int, Account> Accounts { get; set;}

        public AccountManager() 
        {
            Accounts = new Dictionary<int, Account>();
        }

        public int AddCurrent(Branch AssociatedBranch, string phoneNumber)
        {
            CurrentAccount Account = new CurrentAccount(AssociatedBranch, phoneNumber);
            Accounts.Add(Account.AccountNumber, Account);
            return Account.AccountNumber;
        }

        public int AddSavings(Branch AssociatedBranch, string phoneNumber)
        {
            SavingsAccount Account = new SavingsAccount(AssociatedBranch, phoneNumber);
            Accounts.Add(Account.AccountNumber, Account);
            return Account.AccountNumber;
        }

    }
}

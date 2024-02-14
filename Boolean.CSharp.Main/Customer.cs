using Boolean.CSharp.Main.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public string FirstName;
        public string LastName;
        public List<Account> Accounts = new List<Account>();
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public void CreateChecking(string name)
        {
            CheckingAccount newAccount = new CheckingAccount()
            {
                Name = name,
                Balance = 0,
                FreeWithdrawals = 10000
            };
            Accounts.Add(newAccount);
        }

        public void CreateSaving(string name)
        {
            SavingAccount newAccount = new SavingAccount()
            {
                Name = name,
                Balance = 0,
                FreeWithdrawals = 10
            };
            Accounts.Add(newAccount);
        }
    }
}

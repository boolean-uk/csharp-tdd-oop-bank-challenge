using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.BankAccountClasses;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private Dictionary<int, BankAccount> _bankAccounts = new Dictionary<int, BankAccount>();

        public Dictionary<int, BankAccount> BankAccounts { get => _bankAccounts; }

        public Bank()
        {

        }

        public bool CreateAccount(BankAccount currentAccount)
        {
            _bankAccounts.Add(currentAccount.CustomerID, currentAccount);
            return true;
        }

        public BankAccount GetAccount(string accountName, int customerID)
        {
            foreach (var account in _bankAccounts)
            {
                if (account.Value.CustomerID == customerID & account.Value.AccountName == accountName)
                {
                    return account.Value;
                }
            }

            return null;
        }
    }
}

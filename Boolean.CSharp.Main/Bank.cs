using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

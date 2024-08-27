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
        private Dictionary<int, BankAccount> _bankAccounts;

        public Dictionary<int, BankAccount> BankAccounts { get => _bankAccounts; }

        public Bank()
        {

        }
    }
}

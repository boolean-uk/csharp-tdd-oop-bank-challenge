using Boolean.CSharp.Main.BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private Dictionary<int, IBankAccount> _bankAccounts;

        public Dictionary<int, IBankAccount> BankAccounts;
    }
}

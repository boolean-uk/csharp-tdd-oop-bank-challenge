using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountNumber) : base(accountNumber, AccountType.Current) { }
    }
}

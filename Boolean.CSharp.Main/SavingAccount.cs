using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingAccount : Account
    {
        public SavingAccount(string accountNumber, double balance) : base(accountNumber, balance, "saving")
        {
        }
    }
}

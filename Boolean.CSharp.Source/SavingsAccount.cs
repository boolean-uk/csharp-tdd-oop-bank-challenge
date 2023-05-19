using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Source
{
    public class SavingsAccount
    {
        public decimal balance;

        public decimal DepositSaving(decimal deposit)
        {
            balance=+deposit;
            return balance; ;
        }

        public decimal WithdrawSaving(decimal withdraw)
        {
            balance=-withdraw;
            return balance;
        }
    }
}

using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Engineer
    {
        public double CalculateBalance(Account account)
        {
            double balance = 0;

            foreach (var transaction in account.GetTransactions())
            {
                balance += transaction.Amount;
            }

            return balance;
        }
    }
}

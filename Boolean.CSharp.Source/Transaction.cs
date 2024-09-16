using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Source
{
    public class Transaction
    {
        // for current and savingsaccount
        // display transactions (deposits and withdraws)
        // including dates
        // balance after each transaction
        public DateTime date { get; set; }
        public decimal credit { get; set; }
        public decimal debit { get; set; }
        public decimal newBalance { get; set; }

        // foreach transaction (deposit/withdraw) output
        // date credit debit newBalance this is in Account
    }
}

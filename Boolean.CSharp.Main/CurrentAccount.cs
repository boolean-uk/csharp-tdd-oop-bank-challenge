using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(Customer customer, string branch, int accountNumber) : base(customer, branch, accountNumber)
        {
        }

        public bool overDraft { get; set; } = false;

        public override bool transaction(Transactions transaction)
        {
            if (getBalance() + transaction.Amount >= 0f || overDraft)
            {
                transactions.Add(transaction);
                return true;
            }
            Console.WriteLine(getBalance() + transaction.Amount > 0f);
            return false;
        }
    }
}

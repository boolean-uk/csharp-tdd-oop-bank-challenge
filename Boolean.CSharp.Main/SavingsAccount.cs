using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public override bool Deposit(decimal amount)
        {
            return true;
        }

        public override bool Withdraw(decimal amount)
        {
            return true;
        }

        public override string GenerateStatement()
        {
            return "";
        }
        protected override void RecordTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public override decimal GetBalance()
        {
            return 0m;
        }
    }


}

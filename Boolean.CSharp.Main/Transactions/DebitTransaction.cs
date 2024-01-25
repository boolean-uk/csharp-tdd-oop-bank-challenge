using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class DebitTransaction : ITransaction
    {
        private decimal amount;
        private DateTime date;

        public DebitTransaction(decimal amount)
        {
            this.date = DateTime.Now;
            this.amount = amount;
        }

        public decimal EffectOnBalance()
        {
            return -amount;
        }

        public decimal Amount { get => amount; }
        public DateTime Date { get => date; }
    }
}

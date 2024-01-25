using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class OverdraftTransaction : ITransaction
    {
        private decimal amount;
        private DateTime date;
        private ITransaction underlyingTransaction;
        private bool isApproved;

        public OverdraftTransaction(ITransaction transaction)
        {
            this.date = DateTime.Now;
            this.underlyingTransaction = transaction;
            this.amount = 0;
            this.isApproved = false;
        }

        public void Approve()
        {
            if (!this.isApproved)
            {
                this.isApproved = true;
                this.amount = this.underlyingTransaction.Amount;
            }
        }

        public decimal EffectOnBalance()
        {
            return -amount;
        }

        public decimal Amount { get => amount; }
        public DateTime Date { get => date; }
    }
}

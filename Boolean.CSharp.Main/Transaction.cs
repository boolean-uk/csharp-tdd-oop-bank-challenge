using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main
{

    public class Transaction
    {
        private TransactionType type;
        private decimal amount;
        private decimal oldBalance;
        private decimal newBalance;
        private DateTime date;

        public Transaction(TransactionType type, decimal amount, DateTime date)
        {
            this.type = type;
            this.amount = amount;
            this.date = date;
        }

        public TransactionType Type { get => this.type; set => this.type = value; }
        public decimal Amount { get => this.amount; set => this.amount = value; }
        public decimal OldBalance { get => this.oldBalance; set => this.oldBalance = value; }
        public decimal NewBalance { get => this.newBalance; set => this.newBalance = value; }
        public DateTime Date { get => this.date; }
        
    }
}

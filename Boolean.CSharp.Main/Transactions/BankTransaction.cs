using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Transactions
{
    public class BankTransaction
    {
        public int Id = 0;
        public TransactionType TransactionType { get; set; }
        //public TransactionStatus Status { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public double NewBalance { get; set; }
        public double OldBalance { get; set; }


        public BankTransaction(TransactionType TransactionType, double amount, double newBalance, double oldBalance) 
        {
            this.Id++;
            this.TransactionType = TransactionType;
            this.Date = DateTime.Now.ToString("yyyy - mm - dd HH:mm:ss");
            this.Amount = amount;
            this.NewBalance = newBalance;
            this.OldBalance = oldBalance;
        }
    }
}

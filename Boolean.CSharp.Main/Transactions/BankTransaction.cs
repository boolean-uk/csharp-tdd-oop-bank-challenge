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
        public string TransactionType { get; set; }
        //public TransactionStatus Status { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public double NewBalance { get; set; }
        public double OldBalance { get; set; }

        public List<BankTransaction> transactionList { get; set; } = new List<BankTransaction>();

        public BankTransaction(string TransactionType, double amount, double newBalance, double oldBalance) 
        {
            this.Id++;
            this.TransactionType = TransactionType;
            this.Date = DateTime.Now.ToString("yyyy - mm - dd HH:mm:ss");
            this.Amount = amount;
            this.NewBalance = newBalance;
            this.OldBalance = oldBalance;
        }

        public BankTransaction(string TransactionType, double amount, double newBalance)
        {
            this.Id++;
            this.TransactionType = TransactionType;
            this.Date = DateTime.Now.ToString("yyyy - mm - dd HH:mm:ss");
            this.Amount = amount;
            this.NewBalance = newBalance;
        }

        public string ToString()
        {
            return $"{Id} {TransactionType} {Date} {Amount} {NewBalance} {OldBalance}";
        }
    }
}

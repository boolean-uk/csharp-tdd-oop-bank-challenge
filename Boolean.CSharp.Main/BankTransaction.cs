using Boolean.CSharp.Main.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class BankTransaction
    {
        public Enums.Transaction Transaction_type { get; set; }
        public int Amount { get; set; }
        public int OldBalance { get; set; }
        public int NewBalance { get; set; }


        // public string account_id;

        // List<System.Transactions.Transaction> TransactionHistory = new List<System.Transactions.Transaction>();


        public int Calculate_Transaction(string transaction_type, int amount, object IAccount)
        {
            this.Amount = amount;
            if (transaction_type == "Withdraw")
            {
                this.Transaction_type = Enums.Transaction.Withdraw;
                if (IAccount.GetType() == typeof(CurrentAccount))
                {
                    NewBalance = ((CurrentAccount)IAccount).balance - amount;
                    ((CurrentAccount)IAccount).balance = NewBalance;
                }
                else if (IAccount.GetType() == typeof(SavingsAccount))
                {
                    NewBalance = ((SavingsAccount)IAccount).balance - amount;
                    ((SavingsAccount)IAccount).balance = NewBalance;
                }

            }
            else if (transaction_type == "Deposit")
            {
                this.Transaction_type = Enums.Transaction.Deposit;
                if (IAccount.GetType() == typeof(CurrentAccount))
                {
                    NewBalance = ((CurrentAccount)IAccount).balance + amount;
                    ((CurrentAccount)IAccount).balance = NewBalance;
                }
                else if (IAccount.GetType() == typeof(SavingsAccount))
                {
                    NewBalance = ((SavingsAccount)IAccount).balance + amount;
                    ((SavingsAccount)IAccount).balance = NewBalance;
                }

            }
            this.NewBalance = NewBalance;
            return NewBalance;
        }
    }
}

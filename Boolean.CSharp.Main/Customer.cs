using Boolean.CSharp.Main.Enums;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public List<BankTransaction> TransactionHistory { get; } = new List<BankTransaction>();


        public string generateStatement()
        {
            StringBuilder statement = new StringBuilder();
            statement.AppendFormat("{0,10} || {1,10} || {2,10} || {3,10}", "Date", "Credit", "Debit", "Balance");
            statement.AppendLine();

            foreach (BankTransaction transaction in TransactionHistory.OrderByDescending(t => t.Date))
            {
                statement.AppendFormat($"{transaction.Date} || {((transaction.TransactionType == Enums.Transaction.Deposit) ? transaction.Amount : 0),10} || {((transaction.TransactionType == Enums.Transaction.Withdraw) ? transaction.Amount : 0),10} || {transaction.NewBalance:F2}");
                statement.AppendLine();
            }

            Console.WriteLine(statement.ToString());

            return statement.ToString();
        }


        public void pendingOverdraft(CurrentAccount account)
        {
            if (account.overdraft_amount <= 2000)
            {
                account.Overdraft = Overdraft.Approved;
            }
            else
            {
                account.Overdraft = Overdraft.Rejected;
            }
        }

        public decimal BalanceFromTransactions(List<BankTransaction> transactionHistory)
        {
            decimal balance = 0;

            foreach (BankTransaction transaction in transactionHistory.Where(t => t.TransactionType == Transaction.Withdraw))
            {
                balance = balance - transaction.Amount;
            }
            foreach (BankTransaction transaction in transactionHistory.Where(t => t.TransactionType == Transaction.Deposit))
            {
                balance = balance + transaction.Amount;
            }

            return balance;
        }

    }

}

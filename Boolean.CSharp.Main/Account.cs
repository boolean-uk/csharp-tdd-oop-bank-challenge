using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        List<Transaction> TransactionHistory = new List<Transaction>();
        public decimal Balance = 0;

        public void Deposit(decimal amount) 
        {
            
            Balance += amount;
            TransactionHistory.Add(new Transaction(amount, Balance));
        }

        public string Withdraw(decimal amount) 
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;
                TransactionHistory.Add(new Transaction(-amount, Balance));
                return $"Withdrew {amount}NOK";
            }
            return "Insufficent funds";
        }

        public string BankStatement() 
        { 
            StringBuilder bankStatement = new StringBuilder();

            bankStatement.AppendLine($"{"date", -10} || {"credit", -10} || {"debit", -10} || balance");

            foreach (Transaction transaction in TransactionHistory)
            {
                bankStatement.AppendLine(transaction.ToString());
            }

            return bankStatement.ToString();
        }
    }
}

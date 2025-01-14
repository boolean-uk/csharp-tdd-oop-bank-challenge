using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {

        public List<Transaction> TransactionHistory = new List<Transaction>();

        public decimal Balance { get => TransactionHistory.Sum(s => s.Amount) ;}

        public void Deposit(decimal amount) 
        {
            TransactionHistory.Add(new Transaction(amount));
        }

        public virtual string Withdraw(decimal amount) 
        {
            if (Balance - amount > 0)
            {
                TransactionHistory.Add(new Transaction(-amount));
                return $"Withdrew {amount}NOK";
            }
            return "Insufficent funds";
        }

        public string BankStatement() 
        { 
            StringBuilder bankStatement = new StringBuilder();

            bankStatement.AppendLine($"{"date", -10} || {"credit", -7} || {"debit", -7} || balance");
            bankStatement.AppendLine(new String('-', 11) + "||" + new string('-', 9) + "||" + new string('-', 9) + "||" + new string('-', 10));
            _bankStatementRek(bankStatement, 0, 0);

            return bankStatement.ToString();
        }

        private void _bankStatementRek(StringBuilder bankStatement, decimal balance, int i)
        {
            balance += TransactionHistory[i].Amount;

            if (i < TransactionHistory.Count - 1)
            {
                _bankStatementRek(bankStatement, balance, i + 1);
            }

            bankStatement.AppendLine(TransactionHistory[i].ToString() + $" {balance}");
        }
    }
}

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
    public abstract class Account
    {
       
        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public virtual bool Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                Transactions.Add(new Transaction(DateTime.Today.Date, amount, 0));
                return true;
            }
            else { return false; }
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount >= 0 || amount > this.GetBalance())
            
            {
                
                Transactions.Add(new Transaction(DateTime.Today.Date, 0, amount));
                return true;
            }
            else { return false; }


        }


        public virtual string GenerateStatement()
        {
            StringBuilder statementBuilder = new StringBuilder();
            decimal currentBalance = 0;

            foreach (var transaction in Transactions)
            {
                currentBalance += transaction.Credit - transaction.Debit;

                statementBuilder.AppendLine($"Transaction Date: {transaction.Date}");
                statementBuilder.AppendLine($"Credit: {transaction.Credit}");
                statementBuilder.AppendLine($"Debit: {transaction.Debit}");
                statementBuilder.AppendLine($"Balance at the time of transaction: {currentBalance}");
                statementBuilder.AppendLine();
            }

            return statementBuilder.ToString();
        }


        public virtual decimal GetBalance()
        {
            decimal balance = 0;

            foreach (var transaction in Transactions)
            {
                balance += transaction.Credit - transaction.Debit;
            }

            return balance;
        }
    }


}

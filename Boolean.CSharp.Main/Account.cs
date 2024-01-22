using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        private double balance;
        private List<Transaction> transactionList;
        public Branch AssociatedBranch { get; }

        public Account(Branch associatedBranch)
        {
            balance = 0.0;
            transactionList = new List<Transaction>();
            AssociatedBranch = associatedBranch;
        }

        public void Deposit(double amount, DateTime date)
        {
            balance += amount;
            transactionList.Add(new Transaction(date, amount, TransactionType.CREDIT, balance));
        }

        public double GetBalance()
        {
            double calculatedBalance = 0.0;

            foreach (var transaction in transactionList)
            {
                if (transaction.Type == TransactionType.CREDIT)
                {
                    calculatedBalance += transaction.Credit;
                }
                else
                {
                    calculatedBalance -= transaction.Debit;
                }
            }

            return calculatedBalance;
        }


        public string PrintStatement()
        {
            StringBuilder statement = new StringBuilder();
            statement.AppendLine($"Account in branch: {AssociatedBranch.BranchName}");
            statement.AppendLine("date       || credit  || debit  || balance");

            foreach (var transaction in transactionList)
            {
                // Use the desired date format in the statement
                statement.AppendLine($"{transaction.Date.ToString("dd/MM/yyyy")} || {transaction.Credit.ToString("F")} || {transaction.Debit.ToString("F")} || {transaction.BalanceAtTransactionTime.ToString("F")}");
            }

            return statement.ToString();
        }







        public void Withdraw(double amount, DateTime date)
        {
            if(amount <= balance)
            {
                balance -= amount;
                transactionList.Add(new Transaction(date, amount, TransactionType.DEBIT, balance));
            }
            else
            {
                Console.WriteLine("Insuffienct funds for withdrawal.");
            }
        }
    }
}
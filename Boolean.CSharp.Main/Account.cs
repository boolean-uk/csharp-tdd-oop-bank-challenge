using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Branch Branch { get; set; }

        public decimal Balance { get; protected set; }

        public decimal OverdraftLimit { get; private set; }
        public List<Transaction> Transactions { get; set; }




        public Account(string firstName, string lastName, Branch branch)

        {

            FirstName = firstName;
            LastName = lastName;
            Branch = branch;
            OverdraftLimit = 1000;
            Transactions = new List<Transaction>();


        }

        public string showAccountInfo()
        {
            return $"Account for {FirstName} {LastName}, Branch: {Branch}";
        }

        public virtual void GenerateAccountOverview()
        {
            Console.WriteLine("Base Account Statement");
        
        }

        public void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Type == TransactionType.Deposit)
            {
                Balance += transaction.Amount;  
                Console.WriteLine(Balance);
            }
            else if (transaction.Type == TransactionType.Withdrawal)
            {
                if (Balance - transaction.Amount >= -OverdraftLimit)
                {
                    Balance -= transaction.Amount;  
                }
                else 
                {
                    Console.WriteLine("Insufficient funds for withdrawal, overdraft limit exceeded. ");
                    Console.WriteLine(Balance);
                }
            }
            
            Transactions.Add(transaction);
        }

        public virtual string GenerateStatement()
        {
            var statement = new StringBuilder();
            statement.AppendLine($"Account Statement for {FirstName} {LastName}, Branch: {Branch}");
            statement.AppendLine("Date\t\t\tType\t\tAmount\t\tBalance");

            decimal runningBalance = 0;
            foreach (var transaction in Transactions)
            {
                runningBalance += transaction.Type == TransactionType.Deposit
                    ? transaction.Amount
                    : -transaction.Amount;

                statement.AppendLine($"{transaction.Date}\t{transaction.Type}\t\t{transaction.Amount:C}\t\t{runningBalance:C}");
            }

            Console.WriteLine(statement.ToString());
            return statement.ToString();
        }

    }
}

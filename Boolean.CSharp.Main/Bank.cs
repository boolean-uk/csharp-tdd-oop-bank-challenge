using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank: UserAccount
    {
        private List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Deposit(string accountName, string accountType, decimal amount)
        {
            UserAccount account = UserAccount.GetAccount(accountName, accountType);
            if (account != null)
            {
                account.Balance += amount;
                account.LastUpdateDate = DateTime.Now;
                Transaction depositTransaction = new Transaction(DateTime.Now, amount, "Deposit", account);
                Transactions.Add(depositTransaction);
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

        public void Withdraw(string accountName, string accountType, decimal amount)
        {
            UserAccount account = GetAccount(accountName, accountType);
            if (account != null)
            {
                if (amount <= account.Balance)
                {
                    account.Balance -= amount;
                    account.LastUpdateDate = DateTime.Now;
                    Transaction withdrawalTransaction = new Transaction(DateTime.Now, amount, "Withdrawal", account);
                    Transactions.Add(withdrawalTransaction);
                }
                else
                {
                    Console.WriteLine("Insufficient funds");
                }
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

 
        public void GenerateStatement(UserAccount account)
        {
            Console.WriteLine($"Statement for Account Number: {account.AccountNumber}");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"Date: {transaction.Date}, Amount: {transaction.Amount}, Type: {transaction.TransactionType}");
            }
            Console.WriteLine($"Current Balance: {account.Balance}");
        }

    }
}

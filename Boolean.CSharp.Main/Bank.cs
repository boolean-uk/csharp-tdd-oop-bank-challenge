using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private static Dictionary<string, UserAccount> accountsDictionary = new Dictionary<string, UserAccount>();
        public static void GenerateStatement(UserAccount account)
        {
            Console.WriteLine($"Statement for Account Number: {account.AccountNumber}");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"Date: {transaction.Date}, Amount: {transaction.Amount}, Type: {transaction.TransactionType}");
            }
            Console.WriteLine($"Current Balance: {account.Balance}");
        }

        public static UserAccount GetAccountByNumber(string accountNumber)
        {
            // Retrieve account from the dictionary
            if (accountsDictionary.ContainsKey(accountNumber))
            {
                return accountsDictionary[accountNumber];
            }
            else
            {
                return null;
            }
        }
    }
}

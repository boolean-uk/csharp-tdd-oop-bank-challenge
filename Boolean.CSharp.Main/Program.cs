using System;

namespace Boolean.CSharp.Main
{
    public class Program
    {
        public static void Main()
        {
            // Create an instance of the Account class
            IAccount account = new Account();

            // Perform deposits and withdrawals
            account.Deposit(1000, new DateTime(2012, 1, 10));
            account.Deposit(2000, new DateTime(2012, 1, 13));
            account.Withdraw(500, new DateTime(2012, 1, 14));

            // Print the statement using the PrintStatement method
            PrintAccountStatement(account);
        }

        // Method to print the account statement
        public static void PrintAccountStatement(IAccount account)
        {
            // Call the PrintStatement method of the IAccount interface
            string statement = account.PrintStatement();

            // Output the statement to the console
            Console.WriteLine(statement);
        }
    }
}

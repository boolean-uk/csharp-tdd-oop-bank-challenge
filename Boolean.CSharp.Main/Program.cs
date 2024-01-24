using System;

namespace Boolean.CSharp.Main
{
    public class Program
    {
        public static void Main()
        {
            // Create a Branch
            Branch branch = new Branch("Main Branch");

            // Create an OverdraftManager
            //OverdraftManager overdraftManager = new OverdraftManager();

            // Create an Account associated with the Branch and OverdraftManager
            IAccount account = new Account(branch);//, overdraftManager);

            // Depositing and withdrawing to console
            account.Deposit(1000, new DateTime(2012, 1, 10));
            account.Deposit(2000, new DateTime(2012, 1, 13));
            account.Withdraw(500, new DateTime(2012, 1, 14));

            // Using the print method
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

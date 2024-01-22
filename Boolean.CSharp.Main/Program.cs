using System;

namespace Boolean.CSharp.Main
{
    public class Program
    {
        public static void Main()
        {
            IAccount account = new Account();

            // Depositing and withdrawing to console
            account.Deposit(1000, new DateTime(2012, 1, 10));
            account.Deposit(2000, new DateTime(2012, 1, 13));
            account.Withdraw(500, new DateTime(2012, 1, 14));

            // Using the print method
            PrintAccountStatement(account);
        }
        public static void PrintAccountStatement(IAccount account)
        {
            // PrintStatement from IAccount
            string statement = account.PrintStatement();
            Console.WriteLine(statement);
        }
    }
}

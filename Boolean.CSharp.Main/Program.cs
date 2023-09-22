using System;
using System.Globalization;

namespace Boolean.CSharp.Main
{
    public class Program
    {
        //public static void Main()
        //{
        //    var account = new Account();
        //    account.Deposit(1000);
        //    account.Deposit(2000);
        //    account.Withdraw(500);

        //    PrintBankStatement(account.GenerateStatement());
        //}

        private static void PrintBankStatement(BankStatement statement)
        {
            Console.WriteLine("date       || credit  || debit  || balance");

            foreach (var transaction in statement.Transactions)
            {
                var date = transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                var credit = transaction.IsDeposit ? transaction.Amount.ToString("F2") : "       ";
                var debit = transaction.IsDeposit ? "       " : transaction.Amount.ToString("F2");
                var balance = transaction.Balance.ToString("F2");

                Console.WriteLine($"{date} || {credit} || {debit} || {balance}");
            }
        }
    }
}
using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        public static void PrintTransactions(Account account)
        {
            Console.WriteLine("Date       || Credit  || Debit  || Balance");
            Console.WriteLine("-----------------------------------------");

            foreach (var transaction in account.GetTransactions())
            {
                Console.WriteLine($"{transaction.TransactionDate:dd/MM/yyyy} || " +
                                  $"{(transaction.Amount > 0 ? transaction.Amount.ToString("F2") : "")} || " +
                                  $"{(transaction.Amount < 0 ? (-transaction.Amount).ToString("F2") : "")} || " +
                                  $"{transaction.BalanceAtTransaction.ToString("F2")}");
            }

            Console.WriteLine("-----------------------------------------");
        }
    }

}

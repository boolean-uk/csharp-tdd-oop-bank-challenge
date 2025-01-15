using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        public static void printStatement(Account account)
        {
            account.Transactions().Sort((x, y) => DateTime.Compare(x.DateTimeTrans, y.DateTimeTrans));

            double balance = 0;
            Console.WriteLine($"Customer: {account.Customer.GetCustomerId,-10}");
            Console.WriteLine($"Account: {account,-10}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("date                 || credit     || debit      || balance");

            foreach (var transaction in account.Transactions())
            {
                balance += transaction.Amount;

                string credit = transaction.Amount > 0 ? $"{transaction.Amount:F2}" : "";
                string debit = transaction.Amount < 0 ? $"{-transaction.Amount:F2}" : "";

                Console.WriteLine($"{transaction.GetDate(),-20} || {credit,10} || {debit,10} || {balance,10:N2}");
            }
        }
    }
}

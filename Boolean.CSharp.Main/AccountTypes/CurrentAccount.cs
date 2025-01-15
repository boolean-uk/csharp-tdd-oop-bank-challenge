using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.AccountTypes
{
    public class CurrentAccount(string name, Branch branch) : Account(name, branch)
    {
        public decimal OverdraftLimit { get; set; }

        public override void Withdraw(decimal amount)
        {
            var balance = CalculateBalance();
            if (balance >= amount || amount <= OverdraftLimit + balance)
            {
                Transaction debit = new Transaction(amount, TransactionType.Debit);
                TransactionHistory.Add(debit);
            }
            else
            {
                Console.WriteLine("Withdrawal failed");
            }
        }
    }
}

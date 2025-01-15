using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.AccountTypes
{
    public class CurrentAccount : Account
    {

        public decimal OverdraftLimit { get; set; }
        public CurrentAccount(string name, Branch branch) : base(name, branch)
        {

        }

        public override void Withdraw(decimal amount)
        {
            var balance = CalculateBalance();
            if (balance >= amount || amount <= OverdraftLimit + balance)
            {
                Transaction debit = new Transaction(amount, Enums.TransactionType.Debit);
                TransactionHistory.Add(debit);
            }
            else
            {
                Console.WriteLine("Withdrawal failed");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public Dictionary<int,decimal> AccountBalance { get; set; }

        public CurrentAccount(int AccountNumber)
        {
            this.AccountNumber = AccountNumber;
            AccountBalance = new Dictionary<int, decimal>();
        }
        public decimal Deposit(decimal amount)
        {
            decimal credit = 0;

            if (amount < 0)
            {
                amount = 0;
            }
            decimal value = AccountBalance.FirstOrDefault(t => t.Key == this.AccountNumber).Value;
            Console.WriteLine("VÀLUE " + value);
            credit = value += amount;
            
            AccountBalance[AccountNumber] = credit;
      
            Transaction transaction = new Transaction(DateTime.Now, amount, credit, 0);
            transaction.PrintTransaction();
            

            return credit;
        }

        public decimal Withdraw(decimal amount)
        {
            decimal debit = 0;
            decimal value = AccountBalance.FirstOrDefault(t => t.Key == this.AccountNumber).Value;
            if (amount > 0 && amount <= value)
            {
                debit = value -= amount;
            }

            AccountBalance[AccountNumber] = debit;

            Transaction transaction = new Transaction(DateTime.Now, amount, 0, debit);
            transaction.PrintTransaction();

            return debit;
        }
    }
}

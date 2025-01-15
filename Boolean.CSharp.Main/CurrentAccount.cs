using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {

        public decimal OverdraftLimit { get; set; }
     
        public string CurrentAccountNumber { get; set; }
        public CurrentAccount(string firstName, string lastName, Branch branch)
            : base(firstName, lastName, branch)

        {
            OverdraftLimit = 0;
            Balance = 0;
            CurrentAccountNumber = GenerateCurrentAccountNumber();
        }

        public string GenerateCurrentAccountNumber()
        { 
            return $"SA-{Guid.NewGuid()}";
        
        }

        public override void GenerateAccountOverview()
        {
            Console.WriteLine($"Account Statement for {FirstName} {LastName}, Branch: {Branch}");
            Console.WriteLine($"Account Number: {CurrentAccountNumber}");
            Console.WriteLine($"Balance: {Balance}");
        }
        public void Deposit(decimal amount)
        {
            var transaction = new Transaction(amount, TransactionType.Deposit);
            ApplyTransaction(transaction);  
        }

        
        public void Withdrawal(decimal amount)
        {
            var transaction = new Transaction(amount, TransactionType.Withdrawal);
            ApplyTransaction(transaction);  
        }

        public string RequestOverdraft(decimal amount)
        {
            if (amount > 1000)

            {
                return "Your overdraft-request is rejected";
            }
            else
                OverdraftLimit = amount;
            return $"Overdraft request approved and changed from {OverdraftLimit} to {amount}";
        }
    }
}


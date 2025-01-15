using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public string SavingsAccountNumber { get; set; }
       
        
        public SavingsAccount(string firstName, string lastName, Branch branch)
            : base(firstName, lastName, branch)

        {
            SavingsAccountNumber = GenerateSavingsAccountNumber();
            Balance = 0;
        
        }

        private string GenerateSavingsAccountNumber()

        {
            return $"SA-{Guid.NewGuid()}";
            
        }

        public override void GenerateAccountOverview()
        {
            Console.WriteLine($"Account Statement for {FirstName} {LastName}, Branch: {Branch}");
            Console.WriteLine($"Account Number: {SavingsAccountNumber}");
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

    }
}

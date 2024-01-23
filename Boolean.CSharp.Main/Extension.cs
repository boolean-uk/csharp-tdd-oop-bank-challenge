
using Boolean.CSharp.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum AccountTypeExtension
    {
        Current,
        Savings
    }
    public abstract class BankAccountExtension
    {
        public string AccountNumber { get; }
        public AccountTypeExtension Type { get; }
        public Branch AssociatedBranch { get; }
        private List<Transaction> transactionHistory;
        public decimal MaxOverdraftAmount { get; }

        public BankAccountExtension(string accountNumber, AccountTypeExtension type, Branch associatedBranch, decimal maxOverdraftAmount)
        {
            AccountNumber = accountNumber;
            Type = type;
            transactionHistory = new List<Transaction>();
            AssociatedBranch = associatedBranch;
            MaxOverdraftAmount = maxOverdraftAmount;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount.");
                return;
            }
    
            RecordTransaction(amount);
            Console.WriteLine($"Deposit of {amount:C} successful.");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return;
            }

            RecordTransaction(-amount);
  
            Console.WriteLine($"Withdrawal of {amount:C} successful.");
        }

        public decimal GetBalance(Transaction transaction)
        {
            return transactionHistory
                .Where(t => t.Date <= transaction.Date)
                .Sum(t => t.Amount);
        }

        public void PrintStatement()
        {
            Console.WriteLine($"{"Date",-11}||{"Credit",-12}||{"Debit",-12}||{"Balance",-12}||{"Branch",-12}");

            foreach (var transaction in transactionHistory)
            {
                string credit = transaction.Amount > 0 ? $"{transaction.Amount:C}" : "";
                string debit = transaction.Amount < 0 ? $"{-transaction.Amount:C}" : "";

                Console.WriteLine($"{transaction.Date:dd/MM/yyyy} || {credit,-10} || {debit,-10} || {GetBalance(transaction):C}|| {AssociatedBranch.BranchName,-10}");
            }
        }

        private void RecordTransaction(decimal amount)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Amount = amount
            };

            transactionHistory.Add(transaction);
        }
        public bool RequestOverdraft(decimal requestedAmount)
        {
            if (requestedAmount <= 0)
            {
                Console.WriteLine("Invalid overdraft request amount.");
                return false;
            }

           
            bool isApproved = ProcessOverdraftRequest(requestedAmount);

            if (isApproved)
            {
                Console.WriteLine($"Overdraft request of {requestedAmount:C} approved.");
            }
            else
            {
                Console.WriteLine($"Overdraft request of {requestedAmount:C} denied.");
            }

            return isApproved;
        }
        protected abstract bool ProcessOverdraftRequest(decimal requestedAmount);
    }
   
} 

      public class CurrentAccountExtension : BankAccountExtension
      {
            public CurrentAccountExtension(string accountNumber, Branch associatedBranch) : base(accountNumber, AccountTypeExtension.Current, associatedBranch, maxOverdraftAmount: 1000) {}
    protected override bool ProcessOverdraftRequest(decimal requestedAmount)
    {
     
        if (requestedAmount <= MaxOverdraftAmount)
        {
           return true;
        }
        else
        {
           
            return false;
        }
    }

}

      public class SavingsAccountExtension : BankAccountExtension
      {
            public SavingsAccountExtension(string accountNumber, Branch associatedBranch) : base(accountNumber, AccountTypeExtension.Savings, associatedBranch, maxOverdraftAmount: 0){}
    protected override bool ProcessOverdraftRequest(decimal requestedAmount)
    {
        return false;
    }
}

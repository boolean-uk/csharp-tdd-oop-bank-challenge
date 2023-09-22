using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Collections.Generic;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; private set; }

        public SavingsAccount(decimal interestRate)
        {
            InterestRate = interestRate;
        }

        public decimal CalculateInterest()
        {
            decimal interestAmount = balance * (InterestRate / 12);
            Deposit(interestAmount);
            return interestAmount; 
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > 1000)
            {
                throw new InvalidOperationException("Withdrawal amount exceeds the daily limit.");
            }

            base.Withdraw(amount);
        }
    }
}
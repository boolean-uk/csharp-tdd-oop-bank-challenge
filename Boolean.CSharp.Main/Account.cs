using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private List<Transaction> transactions = new List<Transaction>();
        private Branch branch;
        private Customer customer;
        public double overDrawAmount = 0;

        public Account(Branch branch)
        {
            this.branch = branch;
        }
        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }
        public void deposit(double amount, DateTime date)
        {
            transactions.Add(new Transaction(amount, "DEPOSIT", date));
        }
        public void withdraw(double amount, DateTime date)
        {
            if (amount > Balance() + overDrawAmount)
            {
                Console.WriteLine("Can not withdraw from account");
            }
            else
            {
                transactions.Add(new Transaction(-amount, "WITHDRAWAL", date));
            }
        }
        public string SetOverDrawAmount(double overDrawAmount)
        {
            if (overDrawAmount > Balance() + overDrawAmount)
            {
                Console.WriteLine("Insufficient balance");
                return "Operation canceled.";
            }
            else
            {
                Console.WriteLine($"requested overDrawAmount: {overDrawAmount}. Allow (y/n)");
                string confirmation = Console.ReadLine()?.Trim().ToLower();

                if (confirmation == "y")
                {
                    this.overDrawAmount = overDrawAmount;
                    return "new overdraw amount: " + overDrawAmount;
                }
                else if (confirmation == "n")
                {
                    return "new amount not allowed.";
                }
                else
                {
                    return "Invalid input";
                }
            }
        }

        public double Balance()
        {
            return transactions.Sum(transaction => transaction.Amount);
        }
        public List<Transaction> Transactions()
        {
            return transactions;
        }
        public Branch GetBranch { get { return branch; } }
        public Customer Customer
        {
            get { return customer; }
        }
    }
}

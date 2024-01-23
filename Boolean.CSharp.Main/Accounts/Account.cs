using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        private ICustomer _customer;
        private Branch _branch;
        public Branch Branch { get => _branch; }

        private List<ITransaction> _transactions = new List<ITransaction>();
        private List<ITransaction> _overdraftRequests = new List<ITransaction>();
        public List<ITransaction> Transactions { get => _transactions; set => _transactions = value; }
        public List<ITransaction> OverdraftRequests { get => _overdraftRequests; set => _overdraftRequests = value; }


        public Account(ICustomer customer, Branch branch)
        {
            this._customer = customer;
            this._branch = branch;
        }

        public decimal Deposit(decimal amount)
        {
            if(amount > 0)
            {
                ITransaction newTransaction = new Transaction(amount, GetBalance(), TransactionStatus.Approved, TransactionType.Credit);
                Transactions.Add(newTransaction);
                return newTransaction.NewBalance;
            }
            else
            {
                return 0;
            }

        }

        public decimal Withdraw(decimal amount)
        {
            if(amount > 0)
            {
                ITransaction newTransaction = new Transaction(amount, GetBalance(), TransactionStatus.Approved, TransactionType.Debit);
                Transactions.Add(newTransaction);
                return newTransaction.NewBalance;
            }
            else
            {
                return 0;
            }
        }

        public decimal GetBalance() 
        {
            ITransaction? latestTransaction = Transactions.OrderByDescending(t=>t.Date).Where(t=>t.Status == TransactionStatus.Approved).FirstOrDefault();

            if (latestTransaction != null && latestTransaction.Status == TransactionStatus.Approved)
            {
                return latestTransaction.NewBalance;
            }
            else
            {
                return 0;
            }
        }

        public void RequestOverdraft(decimal amount)
        {
            ITransaction newOverdraftRequest = new Transaction(amount, GetBalance(), TransactionStatus.Pending, TransactionType.Debit); //NoteTOSelf: The balance one must be updated once it is approved
            OverdraftRequests.Add(newOverdraftRequest);
        }

        public string GenerateBankStatement()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{"Date",10} || {"Credit",10} || {"Debit",10} || {"Balance",10}");
            foreach (ITransaction transaction in _transactions.OrderByDescending(t => t.Date).Where(t => t.Status == TransactionStatus.Approved))
            {
                stringBuilder.AppendLine(
                    $"{transaction.Date.ToShortDateString(),10}" +
                    $" || {(transaction.Type == TransactionType.Credit ? transaction.Amount : 0),10} " +
                    $"|| {(transaction.Type == TransactionType.Debit ? transaction.Amount : 0),10} || " +
                    $"{transaction.NewBalance,10} ");
            }
            Console.WriteLine("THIS IS THE METHOD:");
            Console.WriteLine( stringBuilder.ToString() ); //Visual 
            return stringBuilder.ToString();
        }
    }
}

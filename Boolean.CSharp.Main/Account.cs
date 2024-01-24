using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        //private bool overdraftRequestPending;
        private double balance;
        private List<Transaction> transactionList;
        //private OverdraftManager overdraftManager;

        //public bool OverdraftApproved { get; set; }
        //private const double MaxOverdraftAmount = 500.0;
        public Branch AssociatedBranch { get; }

       /* public bool GetOverdraftApproved()
        {
            return OverdraftApproved;
        }*/

        /*public void RequestOverdraft(double amount)
        {
            if (overdraftManager.ApproveOverdraftRequest(amount))
            {
                overdraftRequestPending = true;
                Console.WriteLine($"Your account has requested overdraft. Requested amount: {amount}");
            }
            else
            {
                Console.WriteLine("Overdraft request was not approved.");
            }
        }*/

        public Account(Branch associatedBranch)//, OverdraftManager manager)
        {
            balance = 0.0;
            transactionList = new List<Transaction>();
            AssociatedBranch = associatedBranch;
            //OverdraftApproved = false;
            //overdraftManager = manager;
        }

        public void Deposit(double amount, DateTime date)
        {
            balance += amount;
            transactionList.Add(new Transaction(date, amount, TransactionType.CREDIT, balance));
        }

        public double GetBalance()
        {
            double calculatedBalance = 0.0;

            foreach (var transaction in transactionList)
            {
                if (transaction.Type == TransactionType.CREDIT)
                {
                    calculatedBalance += transaction.Credit;
                }
                else
                {
                    calculatedBalance -= transaction.Debit;
                }
            }

            return calculatedBalance;
        }

        public string PrintStatement()
        {
            StringBuilder statement = new StringBuilder();
            statement.AppendLine($"Account in branch: {AssociatedBranch.BranchName}");
            statement.AppendLine("date       || credit  || debit  || balance");

            foreach (var transaction in transactionList)
            {
                // Use the desired date format in the statement
                statement.AppendLine($"{transaction.Date.ToString("dd/MM/yyyy")} || {transaction.Credit.ToString("F")} || {transaction.Debit.ToString("F")} || {transaction.BalanceAtTransactionTime.ToString("F")}");
            }

            return statement.ToString();
        }

        public void Withdraw(double amount, DateTime date)
        {
            double availableFunds = balance;//+ (OverdraftApproved ? MaxOverdraftAmount : 0);

            Console.WriteLine($"Balance: {balance}, Available Funds: {availableFunds}"); //OverdraftApproved:{OverdraftApproved}, MaxOverdraftAmount: {MaxOverdraftAmount},

            if (amount <= availableFunds)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                }
                /*else if (OverdraftApproved)
                {
                    overdraftRequestPending = false; // Used overdraft!
                    balance = 0;
                }*/
                else
                {
                    Console.WriteLine("Insufficient funds for withdrawal.");
                    return; // Stop processing if there are insufficient funds.
                }

                transactionList.Add(new Transaction(date, amount, TransactionType.DEBIT, balance));
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }

            Console.WriteLine($"New Balance: {balance}");
        }
    }
}
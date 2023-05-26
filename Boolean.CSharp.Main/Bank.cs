using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public List<CurrentAccount> currentAccounts = new List<CurrentAccount>();
        public List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        public List<Overdraft> overdrafts = new List<Overdraft>();


        public void CreateAccount(string CustomerName, AccountType type, BranceType branceType = BranceType.noBrance)
        {
            if (type == AccountType.Current)
            {
                currentAccounts.Add(new CurrentAccount() { _CustomerName = CustomerName, _branceType = branceType });
            }
            else if (type == AccountType.Saving)
            {
                savingsAccounts.Add(new SavingsAccount() { _CustomerName = CustomerName, _branceType = branceType });
            }
        }



        public void AddTransaction(string name, AccountType accountType, TransactionType transactionType, decimal amount)
        {
            if (accountType == AccountType.Current)
            {
                Transaction transaction = new Transaction();
                transaction.DateTime = DateTime.Now;
                transaction.amount = amount;
                transaction.transactionType = transactionType;
                if (transactionType == TransactionType.deposit)
                {
                    currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance += amount;
                    transaction.newBalance = currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance;

                }
                else if (transactionType == TransactionType.withdraw && amount <= currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance)
                {
                    currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance -= amount;
                    transaction.newBalance = currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance;
                }
                else if (transactionType == TransactionType.withdraw && amount > currentAccounts.FirstOrDefault(i => i._CustomerName == name)._balance)
                {
                    OverdraftRequest(amount, name, accountType);
                }

                currentAccounts.FirstOrDefault(i => i._CustomerName == name).transactions.Add(transaction);
            }
            else if (accountType == AccountType.Saving)
            {
                Transaction transaction = new Transaction();
                transaction.DateTime = DateTime.Now;
                transaction.amount = amount;
                transaction.transactionType = transactionType;
                if (transactionType == TransactionType.deposit)
                {
                    savingsAccounts.FirstOrDefault(i => i._CustomerName == name)._balance += amount;
                    transaction.newBalance = savingsAccounts.FirstOrDefault(i => i._CustomerName == name)._balance;
                }
                else if (transactionType == TransactionType.withdraw && amount <= savingsAccounts.FirstOrDefault(i => i._CustomerName == name)._balance)
                {
                    savingsAccounts.FirstOrDefault(i => i._CustomerName == name)._balance -= amount;
                    transaction.newBalance = savingsAccounts.FirstOrDefault(i => i._CustomerName == name)._balance;
                }
                else if (transactionType == TransactionType.withdraw && amount > savingsAccounts.FirstOrDefault(i => i._CustomerName == name)._balance)
                {
                    OverdraftRequest(amount, name, accountType);
                }
                savingsAccounts.FirstOrDefault(i => i._CustomerName == name).transactions.Add(transaction);
            }
        }

        public void OverdraftRequest(decimal amount, string name, AccountType accountType)
        {
            int id = overdrafts.Count == 0 ? 1 : overdrafts.Max(o => o._id) + 1;
            overdrafts.Add(new Overdraft() { _amount = amount, _name = name, accountType = accountType, _id = id });
        }

        public void AcceptOverdraftById(int id) 
        {
            overdrafts.FirstOrDefault(i => i._id == id)._status = true;
        }

        public void PrintAccount(string name, AccountType accountType)
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            if (accountType == AccountType.Current)
            {

                foreach (Transaction transaction in currentAccounts.FirstOrDefault(i => i._CustomerName == name).transactions.OrderByDescending(t => t.DateTime))
                {
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                            transaction.DateTime.ToShortDateString(),
                            transaction.transactionType == TransactionType.withdraw ? "" : transaction.amount,
                            transaction.transactionType == TransactionType.deposit ? "" : transaction.amount,
                            transaction.newBalance);
                }
            }
            else if (accountType == AccountType.Saving)
            {
                var find = savingsAccounts.FirstOrDefault(i => i._CustomerName == name);
                foreach (Transaction transaction in find.transactions.OrderByDescending(t => t.DateTime))
                {
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                            transaction.DateTime.ToShortDateString(),
                            transaction.transactionType == TransactionType.withdraw ? "" : transaction.amount,
                            transaction.transactionType == TransactionType.deposit ? "" : transaction.amount,
                            transaction.newBalance);
                }
            }
        }

    }
}

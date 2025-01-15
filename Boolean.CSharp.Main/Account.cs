﻿using System;
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
        public void deposit(double amount)
        {
            transactions.Add(new Transaction(amount, "DEPOSIT"));
        }
        public void withdraw(double amount)
        {
            if (amount > Balance() + overDrawAmount)
            {
                Console.WriteLine("Can not withdraw from account");
            }
            else
            {
                transactions.Add(new Transaction(-amount, "WITHDRAWAL"));
            }
        }
        public string setOverDrawAmount(double overDrawAmount)
        {
            if (overDrawAmount > Balance() + overDrawAmount)
            {
                Console.WriteLine("insufficient balance");
            }
            else
            {
                this.overDrawAmount = overDrawAmount;
                return "New over draw amount: " + overDrawAmount;
            }
            return "OK";
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

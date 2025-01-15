using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Boolean.CSharp.Main.Enums;


namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        public Guid accountNumber;
        public string accountName;
        public Branch branch;
        public List<Transaction> accountTransactions = new List<Transaction>();

        public void depositAmount(decimal amount)
        {
            accountTransactions.Add(new Transaction(amount, TransactionType.Deposit));
            SendToPhone("Successfully deposited: £" + amount);
        }

        public void withdrawAmount(decimal amount)
        {
            if (getBalance() >= amount)
            {
                accountTransactions.Add(new Transaction(amount, TransactionType.Withdraw));
                SendToPhone("Successfully withdrew: £" + amount);
            }

            else
                Console.WriteLine("Insuffuient funds, request an overdraft instead!");
        }

        public decimal transactionHelper()
        {
            decimal balance = 0;
            Console.WriteLine("date       || credit  || debit  || balance");
            accountTransactions.ForEach(t =>
            {
                if (t.DepositAmount != 0)
                {
                    balance += t.DepositAmount;
                    Console.WriteLine(String.Format("{0,11}||{1,9}||        ||{2,8}||", t.Date.ToString("dd/MM/yyyy"), t.DepositAmount, balance));
                } else
                {
                    balance -= t.WithdrawAmount;
                    Console.WriteLine(String.Format("{0,11}||         ||{1,8}||{2,8}||", t.Date.ToString("dd/MM/yyyy"), t.WithdrawAmount, balance));


                }

            });
            return balance;
        }

        public decimal getBalance()
        {
            decimal balance = 0;
            accountTransactions.ForEach(t =>
            {
                if (t.DepositAmount != 0)
                {
                    balance += t.DepositAmount;
                }
                else
                {
                    balance -= t.WithdrawAmount;
                }
            });
            return balance;
        }

        public void RequestOverdraft(decimal amount, bool allowed)
        {
            if(allowed)
            {
                accountTransactions.Add(new Transaction(amount, TransactionType.Withdraw));
                Console.WriteLine("Your request has been approved");
            }
            else
            {
                Console.WriteLine("Your request was rejected by the bank manager");
            }
        }

        public void SendToPhone(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}

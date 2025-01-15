using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Interface;
using NUnit.Framework;

namespace Boolean.CSharp.Main.PersonType
{
    public class Customer
    {
    
        public decimal accountBalance { get; set; }
        public string name { get; set; }
        List<IAccount> accounts = new List<IAccount>();
        string location { get; set; }
        decimal overdraftAmount { get; set; } = 0;
        public Customer(string _name, string _location)
        {
            name = _name;
            location = _location;
        }


        public int GetAccountsCount()
        {
            return accounts.Count;
        }

        public void CreateAccount(string type, string _name)
        {
            string toLower = type.ToLower();

            if (toLower == "checkings")
            {
                Checkings checking = new Checkings(_name, location);
                checking.accountHolder = name;
                accounts.Add(checking);
            }

            else if (toLower == "savings")
            {
                Savings savings = new Savings(_name, location);
                savings.accountHolder = name;
                accounts.Add(savings);
            }

            else
            {
                throw new Exception("We don't offer that type of account");
            }
        
        }

        public void RequestOverdraft(decimal number, bool response, IAccount account)
        {
            if (response)
            {
                overdraftAmount += number;
                
            }
        }

        public void Withdrawal(IAccount account, ITransaction transaction)
        {
            decimal maxNum = account.accountBalance + overdraftAmount;
            if (transaction.transactionAmount > maxNum)
            { 
                    throw new Exception($"You don't have enough in your balance to withdraw the £{transaction.transactionAmount}");
                }

                if (transaction.transactionAmount <= overdraftAmount + account.accountBalance)
                {
                    account.accountBalance -= transaction.transactionAmount;
                    transaction.balance = account.accountBalance;
                    account.AddTransaction(transaction);
                    
                }
            }

        public IAccount GetAccount(string name)
        {
            foreach (IAccount account in accounts)
            {
                if (account.name == name)
                {
                    return account;
                }
            }
            throw new Exception($"There is no account associated with {name}.");
        }


        public void Deposit(IAccount account, ITransaction transaction)
        {
            account.accountBalance += transaction.transactionAmount;
            transaction.balance = account.accountBalance;
            account.AddTransaction(transaction);
            
        }

        public void PrintBankStatement(IAccount account)
        {
            Console.WriteLine("date        || credit   || debit    || balance");

            foreach(ITransaction transaction in account.GetTransactions())
            {
                transaction.PrintTransactions();    
            }

        }

        public decimal GetAccountBalanceFromTransactions(IAccount account)
        {
            decimal balance = 0;
            
            foreach(ITransaction transaction in account.GetTransactions())
            {
                if (transaction.type == "Credit")
                {
                    balance += transaction.transactionAmount;
                }
                else
                {
                    balance -= transaction.transactionAmount;
                }
            }
            return balance;
        }


    }
}

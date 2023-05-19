using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main.BankAccounts
{
    public class BankAccount
    {
        private Transaction transcation;
        private IUser user;
        private decimal balance;
        //either current or savings account
        private AccountType typeOfAccount;
        private List<Transaction> listOfTransactions = new List<Transaction>();

        public BankAccount(IUser user)
        {
            this.user = user;
        }

        public string DepositFunds(Transaction transaction)
        {
            if (transaction != null)
            {
                if (transaction.Type == TransactionType.Credit)
                {
                    if (transaction.Amount > 0)
                    {
                        if (listOfTransactions.Count == 0)
                        { 
                            this.balance = 0;
                            transaction.OldBalance = this.balance;
                            this.balance += transaction.Amount;
                            transaction.NewBalance = this.balance;
                            this.listOfTransactions.Add(transaction);
                            return "Deposit has been made successfully";

                        }
                        else
                        {
                            transaction.OldBalance = this.balance;
                            this.balance = +transaction.Amount;
                            transaction.NewBalance = this.balance;
                            this.listOfTransactions.Add(transaction);
                            return "Deposit has been made successfully"; 
                        }
                    }
                }
            }
            return "Nothing to deposit"; 
        }

        public string WithdrawFunds(Transaction transaction)
        {
            if (transaction != null)
            {
                if (transaction.Type == TransactionType.Debit)
                {
                    if (transaction.Amount > 0)
                    {
                        if (this.balance >= transaction.Amount)
                        {
                            transaction.OldBalance = balance;
                            this.balance -= transaction.Amount;
                            transaction.NewBalance = this.balance;
                            this.listOfTransactions.Add(transaction);
                            return "Withdrawal has been made successfully";
                        }
                    }
                }
            }
            return "Nothing to withdraw";
        }
            
        public decimal CalculateBalance()
        {
            decimal total = 0;
            if (listOfTransactions.Count > 0)
            {
                foreach (var transaction in listOfTransactions)
                {
                    if (transaction.Type == TransactionType.Credit)
                    {
                        total += transaction.Amount;
                    } else
                    {
                        total -= transaction.Amount;
                    }
                }
                return total;
            }
            return total;
        }

        public IUser User { get => this.user; }
        public decimal Balance { get => this.balance; }
        public AccountType TypeOfAccount { get => this.typeOfAccount; set => this.typeOfAccount = value; }
        public List<Transaction> ListOfTransactions { get => this.listOfTransactions; }
    }
}

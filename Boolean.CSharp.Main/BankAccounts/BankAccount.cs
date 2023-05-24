using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.IUsers;
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
        private AccountType typeOfAccount;
        private List<Transaction> listOfTransactions = new List<Transaction>();
        private Branches branch;
        private List<OverdraftRequest> overdraftRequests = new List<OverdraftRequest>();

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
                        if (this.balance + OverdraftChecking() >= transaction.Amount)
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

        public decimal OverdraftChecking()
        {
            var overdraftRequest = OverdraftRequests.OrderByDescending(x => x.Date).Where(x => x.Status == Status.Approved).FirstOrDefault();
            if (overdraftRequest != null)
            {
                return overdraftRequest.Amount;
            }
            return 0;
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

        public string ApplyForOverdraft(OverdraftRequest request)
        { 
            if (request != null)
            {
                overdraftRequests.Add(request);
                return "Your request has been added to the list";
            }
            return "There isn't any request";
        }

        public void SendSms(ISmsSender provider)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Date      || Credit || Debit || Balance\n");
            
            foreach(var transaction in listOfTransactions.OrderByDescending(x => x.Date))
            {
                string date = transaction.Date.ToShortDateString();
                decimal creditAmount = transaction.Type == TransactionType.Credit ? transaction.Amount : 0;
                decimal debitAmount = transaction.Type == TransactionType.Debit ? transaction.Amount : 0;
                decimal balance = transaction.NewBalance;
                sb.Append(date + "      || " + creditAmount + " || " + debitAmount + " || " + balance);
            }

            provider.SendSMS(sb.ToString());
            //provider.SendSMS("Have a nice day");
        }


        public IUser User { get => this.user; }
        public decimal Balance { get => this.balance; set => this.balance = value; }
        public AccountType TypeOfAccount { get => this.typeOfAccount; set => this.typeOfAccount = value; }
        public Branches Branch { get => this.branch; set => this.branch = value; }
        public List<Transaction> ListOfTransactions { get => this.listOfTransactions; }
        public List<OverdraftRequest> OverdraftRequests { get => this.overdraftRequests; }
    }
}

using Boolean.CSharp.Main.BankAccounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.IUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();
        private IUser manager;
        public Bank(IUser manager)
        {
            this.manager = manager;
        }

        public string CreateAccount(BankAccount account, AccountType accountType, Branches branch)
        {
            if (account != null)
            {
                if (manager is BankManager)
                {
                    if (accountType == AccountType.Current)
                    {
                        if (account.User.HasCurrentAccount == false)
                        {
                            account.TypeOfAccount = accountType;
                            account.User.HasCurrentAccount = true;
                            account.Branch = branch;
                            bankAccounts.Add(account);
                            return $"Current account created sucessfully for {account.User.Name}";
                        }
                        return $"A current account already exists for {account.User.Name}";
                    }
                    else
                    {
                        if (account.User.HasSavingsAccount == false)
                        {
                            account.TypeOfAccount = accountType;
                            account.User.HasSavingsAccount = true;
                            account.Branch = branch;
                            bankAccounts.Add(account);
                            return $"Savings account created sucessfully for {account.User.Name}";
                        }
                        return $"A savings account already exists for {account.User.Name}";
                    }
                }
                return "You are not a Manager";
            }
            return "Account has not been provided";
        }

        public void GenerateStatement(BankAccount account)
        {
            if (manager is BankManager)
            {
                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", "Date", "Credit", "Debit", "Balance");
                foreach (var transaction in account.ListOfTransactions.OrderByDescending(t => t.Date))
                {
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}",
                        transaction.Date.ToShortDateString(),
                        transaction.Type == TransactionType.Credit ? transaction.Amount : 0,
                        transaction.Type == TransactionType.Debit ? transaction.Amount : 0,
                        transaction.NewBalance);
                }
            }
        }

        public string CheckRequest(OverdraftRequest request)
        {
            if (manager is BankManager)
            {
                if(request != null)
                {
                    request.Status = Status.Approved;
                    return "request has been approved";
                }
                return "request has not been approved";
            }
            return "You are not a manager";
        }

        public IUser Manager { get => this.manager; set => this.manager = value; }
        public List<BankAccount> BankAccounts { get => this.bankAccounts; set => this.bankAccounts = value; }
    }
}

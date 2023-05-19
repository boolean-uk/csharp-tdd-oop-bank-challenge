using Boolean.CSharp.Main.BankAccounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();
        public Bank()
        {

        }

        public string CreateAccount(BankAccount account, AccountType accountType)
        {
            if (account != null)
            {
                if (accountType == AccountType.Current)
                {
                    if (account.User.HasCurrentAccount == false)
                    {
                        account.TypeOfAccount = accountType;
                        account.User.HasCurrentAccount = true;
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
                        bankAccounts.Add(account);
                        return $"Savings account created sucessfully for {account.User.Name}";
                    }
                    return $"A savings account already exists for {account.User.Name}";
                }
            }
            return "Account has not been provided";
        }

        public void GenerateStatement(BankAccount account)
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
        public List<BankAccount> BankAccounts { get => this.bankAccounts; set => this.bankAccounts = value; }
    }
}

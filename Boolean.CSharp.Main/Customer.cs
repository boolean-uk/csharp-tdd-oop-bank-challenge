using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private List<Account> accounts;

        public Customer()
        {
            accounts = new List<Account>();
        }

        public void CreateSavingsAccount(int accountNumber)
        {
            accounts.Add(new SavingsAccount(accountNumber));
        }

        public void CreateCurrentAccount(int accountNumber)
        {
            accounts.Add(new CurrentAccount(accountNumber));
        }

        public void Deposit(int accountNumber, double amount)
        {
            var account = accounts.Find(a => a.accountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw(int accountNumber, double amount)
        {
            var account = accounts.Find(a => a.accountNumber == accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public Account GetSpecifiedAccount(int accountNumber)
        {
            return accounts.Find(a => a.accountNumber == accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }

        public void GenerateBankStatement(int accountNumber)
        {
            var account = GetSpecifiedAccount(accountNumber);
            if (account != null)
            {
                BankStatement.PrintTransactions(account);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

}


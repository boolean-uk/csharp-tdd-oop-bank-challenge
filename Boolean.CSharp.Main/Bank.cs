using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {

        private List<Account> _accounts = new List<Account>();

        private List<string> _users { get { return _accounts.Select(account => account.Owner).Distinct().ToList(); } }
        public int AddAccount(string user, string bankType)
        {

            if (bankType == "current")
            {
                Account account = new CurrentAccount(_accounts.Count(), bankType, user);
                _accounts.Add(account);

                return account.ID;
            }
            if (bankType == "savings")
            {
                Account account = new SavingsAccount(_accounts.Count(), bankType, user);
                _accounts.Add(account);
                return account.ID;
            }
            
            return -1;
        }

        public double Deposit(int ID, double amount)
        {
            if (_accounts.Where(account => account.ID == ID).Count() == 0)
            {
                return 0;
            }

            Account AcctoBeDeposited = _accounts.Where(account => account.ID == ID).First();
            Transaction transaction = new Transaction(DateTime.Today.ToString("dd/MM/yyyy"), AcctoBeDeposited.Balance, amount, 0);
            AcctoBeDeposited.TransactionHistory.Add(transaction);

            AcctoBeDeposited.AddBalance(amount);
            return AcctoBeDeposited.Balance;
        }

        public double Withdraw(int ID, double amount)
        {
            if (_accounts.Where(account => account.ID == ID).Count() == 0)
            {
                return 0;
            }

            Account AccToBeWithdrawn = _accounts.Where(account => account.ID == ID).First();
            Transaction transaction = new Transaction(DateTime.Today.ToString("dd/MM/yyyy"), AccToBeWithdrawn.Balance, 0, amount);
            AccToBeWithdrawn.TransactionHistory.Add(transaction);

            AccToBeWithdrawn.RemoveBalance(amount);
            return AccToBeWithdrawn.Balance;
        }

        public string PrintBankStateMent(string user)
        {
            List<Account> accountsWithUser = _accounts.Where(account => account.Owner == user).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"date\t\t|| credit\t|| debit\t|| balance\t");

            foreach (Account account in accountsWithUser)
            {
                sb.AppendLine(account.GenerateStatement());
            }

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Bank
    {
        private string _name;

        private List<Account> _accounts = new List<Account>();

        public Bank(string name)
        {
            this._name = name;
        }

        public Current CreateCurrentAccount(Customer customer, Branch branch, string accountnr)
        {
            Current current = new Current(branch, customer, accountnr);
            _accounts.Add(current);
            return current;
        }

        public Savings CreateSavingsAccount(Customer customer, Branch branch, string accountnr)
        {
            Savings savings = new Savings(branch, customer, accountnr);
            _accounts.Add(savings);
            return savings;
        }

        public string Name { get => _name; set => _name = value; }
        public List<Account> Accounts { get => _accounts; set => _accounts = value; }

        public Account GetAccount(string accountnr)
        {
            var matches = _accounts.FirstOrDefault(x => x.AccountNr == accountnr);
            return matches;
        }

        public Transaction Deposit(string accountnr, double amount)
        {
            Transaction thisTransaction = new Transaction(DateTime.Now, null, amount);
            var matches = _accounts.FirstOrDefault(x => x.AccountNr == accountnr);
            matches.Transactions.Add(thisTransaction);
            return thisTransaction;
        }

        public Transaction Withdraw(string accountnr, double amount)
        {
            double withdrawn = 0 - amount;
            Transaction thisTransaction = new Transaction(DateTime.Now, null, withdrawn);
            var matches = _accounts.FirstOrDefault(x => x.AccountNr == accountnr);
            matches.Transactions.Add(thisTransaction);
            return thisTransaction;
        }
    }
}

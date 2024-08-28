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

        public Current CreateCurrentAccount(Branch branch, Customer customer, string accountnr)
        {
            Current current = new Current(branch, customer, accountnr);
            _accounts.Add(current);
            return current;
        }

        public Savings CreateSavingsAccount(Branch branch, Customer customer, string accountnr)
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
            var matches = _accounts.FirstOrDefault(x => x.AccountNr == accountnr);
            double newBalance = matches.GetBalance() + amount;
            Transaction thisTransaction = new Transaction(DateTime.Now, null, amount, newBalance);
            matches.Transactions.Add(thisTransaction);
            return thisTransaction;
        }

        public Transaction Withdraw(string accountnr, double amount)
        {
            double withdrawn = 0 - amount;
            var matches = _accounts.FirstOrDefault(x => x.AccountNr == accountnr);
            double newBalance = matches.GetBalance() - amount;
            Transaction thisTransaction = new Transaction(DateTime.Now, amount, null, newBalance);
            matches.Transactions.Add(thisTransaction);
            return thisTransaction;
        }

        public string Statement(string customername)
        {
            //StringBuilder sb = new StringBuilder();
            string print = "";
            var matches = _accounts.Where(x => x.Customer.Name == customername).ToList();
            foreach (var match in matches)
            {
                print += match.GetType().Name+" Account with AccountNr: "+match.AccountNr + " in: " + match.Branch.Name+"\n";
                print += "\nDate".ToString().PadRight(15)+"||".ToString().PadRight(5)+"credit".ToString().PadRight(8)+"||".ToString().PadRight(5) + "debit".ToString().PadRight(8)+"||".ToString().PadRight(5) + "balance";
                foreach (Transaction transaction in match.Transactions)
                {
                    print += "\n"+transaction.Date.ToString("d").PadRight(14)+"||".ToString().PadRight(5)+transaction.Credit.ToString().PadRight(8)+"||".ToString().PadRight(5)+transaction.Debit.ToString().PadRight(8)+ "||".ToString().PadRight(5)+transaction.Newbalance.ToString().PadRight(8);
                }
                print += "\n\n";
            }
            return print;
        }

        public void RequestOverdraft(string accountnr, double amount)
        {
            
        }
    }
}

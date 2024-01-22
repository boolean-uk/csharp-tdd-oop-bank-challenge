using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        //Public values
        public string Name { get { return _name; } }
        public double Balance { get { return _balance; } }
        public Branch Branch { get { return _branch; } }

        //Encapsulated values
        private string _name;
        private double _balance = 0d;
        private Branch _branch;
        private readonly List<ITransaction> _transactions = [];

        public Account(Branch branch, string name)
        {
            _branch = branch;
            _name = name;
        }

        public bool makeTransaction(TransactionType type, double amount)
        {
            if (type == TransactionType.Debit && amount > _balance || amount <0)
            {
                return false;
            }
            BankTransaction transaction = new BankTransaction(type, _balance, amount);
            _transactions.Add(transaction);
            _balance = transaction.NewBalance;
            return true;
        }

        public List<ITransaction> GetTransactions()
        {
            return _transactions;
        }

        /// <summary>
        /// Method outputs a statement to the console
        /// </summary>
        public void WriteStatement()
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (ITransaction transaction in _transactions.OrderByDescending(t => t.Date))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                        transaction.Date.ToShortDateString(),
                        transaction.Type == TransactionType.Credit ? transaction.Amount : 0,
                        transaction.Type == TransactionType.Debit ? transaction.Amount : 0,
                        transaction.NewBalance);
            };
        }
    }
}

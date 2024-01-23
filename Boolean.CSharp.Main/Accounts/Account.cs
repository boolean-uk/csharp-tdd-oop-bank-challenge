using Boolean.CSharp.Main.Overdraft;
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
        private readonly List<OverdraftObj> _overdraftRequests = [];

        public Account(Branch branch, string name)
        {
            _branch = branch;
            _name = name;
        }

        public bool MakeTransaction(TransactionType type, double amount)
        {
            double overDraft;
            if (_overdraftRequests.OrderByDescending(r => r.DateTime).Any(r => r.OverdraftStatus == OverdraftStatus.Approved))
            {
                overDraft = (double)_overdraftRequests.OrderByDescending(r => r.DateTime).FirstOrDefault(r => r.OverdraftStatus == OverdraftStatus.Approved).Amount;
            }
            else
            {
                overDraft = 0;
            }

            if (type == TransactionType.Debit
                 && amount > _balance + overDraft || amount < 0)
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

        public double GetBalance() 
        {
            if (_transactions.Count == 0) return 0d;
            return _transactions.OrderByDescending(t=>t.Date).FirstOrDefault().NewBalance; 
        }

        public OverdraftObj CreateOverdraftRequest(double amount)
        {
            if (amount < 0){ return null; }
            OverdraftObj result = new OverdraftObj(_name,amount);
            _overdraftRequests.Add(result);
            return result;
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
        public string GenerateStatementMessage()
        {
            StringBuilder statement = new StringBuilder();
            statement.AppendLine(string.Format("{0,10} || {1,10} || {2,10} || {3,10}", "Date", "Credit", "Debit", "Balance"));

            foreach (ITransaction transaction in _transactions.OrderByDescending(t => t.Date))
            {
                statement.AppendLine(string.Format("{0,10} || {1,10} || {2,10} || {3,10}",
                    transaction.Date.ToShortDateString(),
                    transaction.Type == TransactionType.Credit ? transaction.Amount.ToString() : "0",
                    transaction.Type == TransactionType.Debit ? transaction.Amount.ToString() : "0",
                    transaction.NewBalance.ToString()));
            }

            return statement.ToString();
        }

    }
}

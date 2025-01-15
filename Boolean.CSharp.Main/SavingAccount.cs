using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{

    public class SavingAccount : IAccount
    {
        public List<Transaction> Transactions { get; set; }
        public List<Transaction> Overdraft { get; set; }
        public string User { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public SavingAccount(string user, string branch, string name)
        {
            this.User = user;
            this.Branch = branch;
            this.Name = name;
            Transactions = new List<Transaction>();
            Overdraft = new List<Transaction>();
        }
        public void Deposit(decimal money)
        {
            Transaction adding = new Transaction(TransactionTypes.Add, money, DateTime.Now);
            Transactions.Add(adding);
        }
        public bool Withdraw(decimal money)
        {
            if (money >= Total())
            {
                Transaction adding = new Transaction(TransactionTypes.Subtract, money, DateTime.Now);
                Transactions.Add(adding);
                return true;
            }
            return false;
        }
        public void OverdraftRequest(decimal money)
        {
            Transaction adding = new Transaction(TransactionTypes.Subtract, money, DateTime.Now);
            Overdraft.Add(adding);
        }

        public bool OverdraftApproval(bool admin, bool accept, Guid id)
        {
            if (accept && admin)
            {
                return true;
            }
            return false;
        }
        public decimal Total()
        {
            return Transactions.Sum(x => x.Amount);
        }

        public string BankStatement()
        {
            List<Transaction> orderedTransactions = (List<Transaction>)Transactions.OrderByDescending(x => x.Time);
            decimal balance = Total();
            var statement = new System.Text.StringBuilder();
            statement.AppendLine("date    || credit   || debit   || balance");
            foreach (Transaction transaction in orderedTransactions)
            {
                if (transaction.TransactionType == TransactionTypes.Add)
                {
                    statement.AppendLine(transaction.Time + " || " + "      " + " || " + transaction.Amount + " || " + balance);
                    balance -= transaction.Amount;
                }
                if (transaction.TransactionType == TransactionTypes.Subtract)
                {
                    statement.AppendLine(transaction.Time + " || " + transaction.Amount + " || " + "       " + " || " + balance);
                    balance += transaction.Amount;
                }
            }
            statement.AppendLine();

            return statement.ToString();
        }
    }
}

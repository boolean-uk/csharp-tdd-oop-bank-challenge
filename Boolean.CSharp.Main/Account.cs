using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        public List<Transaction> Transactions { get; set; }
        public List<Transaction> Overdraft { get; set; }
        public string User { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public Account(string user, string branch, string name)
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
            if (money <= Total())
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
            if (admin)
            {
                if (accept) 
                {
                    Transaction accepted = Overdraft.Find(x => x.Id == id);
                    if (accepted is not null)
                    {
                        Transactions.Add(accepted);
                        Overdraft.RemoveAll(x => x.Id == id);
                        return true;
                    }
                    return false;
                }
                else
                {
                    Overdraft.RemoveAll(x => x.Id == id);
                    return false;
                }
            }
            return false;
        }
        public decimal Total()
        {
            decimal added = Transactions.Where(x => x.TransactionType == TransactionTypes.Add).Sum(x => x.Amount);
            decimal subtract = Transactions.Where(x => x.TransactionType == TransactionTypes.Subtract).Sum(x => x.Amount);
            return added - subtract;
        }

        public string BankStatement()
        {
            List<Transaction> orderedTransactions = Transactions.OrderByDescending(x => x.Time).ToList();
            decimal balance = Total();
            var statement = new System.Text.StringBuilder();
            statement.AppendLine("date    || credit   || debit   || balance");
            foreach (Transaction transaction in orderedTransactions)
            {
                if (transaction.TransactionType == TransactionTypes.Add)
                {
                    statement.AppendLine(transaction.Time + "  || " + "        " + " || " + transaction.Amount + "   || " + balance);
                    balance -= transaction.Amount;
                }
                if (transaction.TransactionType == TransactionTypes.Subtract)
                {
                    statement.AppendLine(transaction.Time + "  || " + transaction.Amount + "     || " + "       " + " || " + balance);
                    balance += transaction.Amount;
                }
            }
            statement.AppendLine();

            return statement.ToString();
        }
    }
}
    

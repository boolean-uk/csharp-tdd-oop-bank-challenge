using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Extensions;

namespace Boolean.CSharp.Main.Acounts
{
    public abstract class Account
    {
        public decimal Balance { 
            get
            { 
                return Transactions
                    .Where(x => x.type == TransactionType.CREDIT)
                    .Sum(x => x.amount) - Transactions
                    .Where(x => x.type == TransactionType.DEBIT)
                    .Sum(x => x.amount);
            }
        }

        public Branch associatedBranch { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Branch yourBranch { get; set; }

        public List<OverdraftRequest> OverdraftRequests { get; set; } = new List<OverdraftRequest>();

        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                Transactions.Add(new Transaction { amount = amount, date = DateTime.Now, type = TransactionType.CREDIT, balance = Balance + amount});
            }
            else
            {
                Console.WriteLine("Cant deposit a value like that");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0 || amount > this.Balance)
            {
                Console.WriteLine("Cant withdraw a value like that or you do not have enough money in your account...");
            }
            else
            {
                Transactions.Add(new Transaction { amount = amount, date = DateTime.Now, type = TransactionType.DEBIT, balance = Balance - amount });
            }
        }

        public decimal getBalance()
        {
            return this.Balance;
        }

        public string printStatement()
        {
            string statement = "date       || credit || debit || balance\n";
            foreach (Transaction t in Transactions) 
            {
                statement += $"{t.date.ToString("dd/MM/yyyy")} ||"   ;
                if (t.type == TransactionType.CREDIT)
                {
                    statement += $"  {t.amount}  ||       ||";
                }
                else
                {
                    statement += $"        ||  {t.amount}  ||";
                }
                statement += $"  {t.balance}  \n";
            }


            return statement;
        }

        public void RequestOverdraft(decimal amount)
        {
            OverdraftRequests.Add(new OverdraftRequest(amount, this));    
        }

        public void RequestoToTransaction()
        {
            Withdraw(OverdraftRequests.First().Amount);
        }
    }
}

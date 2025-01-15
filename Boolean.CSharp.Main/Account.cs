using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account : Iaccount
    {

        public List<Transaction> history = new List<Transaction>();
        public decimal CalculateBalance()
        {
            decimal balance = 0;
            foreach (Transaction transaction in history)
            {
                if (transaction.type == "Deposit")
                {
                    balance += transaction.amount;
                }
                else if (transaction.type == "Withdraw")
                {
                    balance -= transaction.amount;
                }
            }
            return balance;
        }

        public void Deposit(decimal amount)
        {
            Transaction transaction = new Transaction("Deposit", amount);
            history.Add(transaction);
        }




        public string GenerateBankStatements()
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal amount)
        {
            Transaction transaction = new Transaction("Withdraw", amount);
            history.Add(transaction);
        }


    }
}

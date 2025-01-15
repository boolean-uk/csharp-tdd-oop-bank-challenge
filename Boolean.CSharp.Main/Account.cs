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
            Console.WriteLine("date                || credit             || debit                || balance                 ||");
            history.ForEach(transaction =>
            {
                
                if (transaction.type == "Withdraw")
                {
                    Console.WriteLine($"{DateTime.Now} ||                    || {transaction.amount}                     ||{this.CalculateBalance()}             ||");
                }
                else if (transaction.type == "Deposit")
                {
                    Console.WriteLine($"{DateTime.Now} ||{transaction.amount}                    ||                      ||{this.CalculateBalance()}             ||");
                }


            });
             return "";


        }

        public void Withdraw(decimal amount)
        {
            Transaction transaction = new Transaction("Withdraw", amount);
            history.Add(transaction);
        }
        

    }
}

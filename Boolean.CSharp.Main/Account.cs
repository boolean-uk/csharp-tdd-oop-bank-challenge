using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public double balance { get; set; } = 0;
        public Branch branch { get; set; }
        public ICollection<Transactions> _transactions = new List<Transactions>();  

        public double getBalance()
        {
            double calculateBalance = 0;
            foreach (var transaction in _transactions)
            {
                if (transaction.transactionType == TransactionType.CREDIT)
                {
                    calculateBalance += transaction.amount;
                } 
                else 
                {
                    calculateBalance -= transaction.amount;
                }
            }
            this.balance = calculateBalance;
            return this.balance;
        }
        public double deposit(double amount)
        {
            Transactions transactions = new Transactions(amount, DateTime.Now, TransactionType.CREDIT);
          
            _transactions.Add(transactions);

            Console.WriteLine($"New balance: {getBalance()}");
            return transactions.amount;
        }

        public double withdraw(double amount)
        {

            Transactions transactions = new Transactions(amount, DateTime.Now, TransactionType.DEBIT);

            if (getBalance() < amount)
            {
                Console.WriteLine("Your balance is to low, change amount!");
                return getBalance();
            }

            _transactions.Add(transactions);

            Console.WriteLine($"New balance: {getBalance()}");
            return transactions.amount;
        }
        
        public string bankStatement()
        {
            string print = $"~~~~~ Account Transactions ~~~~~ \n Date       || Credit || Debit || Balance ";

            double balanceAmount = 0;
            foreach (var transaction in _transactions)
            {
                if (transaction.transactionType == TransactionType.CREDIT)
                {
                    balanceAmount += transaction.amount;
                    print += $" \n {transaction.date.ToString("dd/MM/yyyy")} ||  {transaction.amount}   ||       ||   {balanceAmount}";
                }
                else
                {
                    balanceAmount -= transaction.amount;
                    print += $" \n {transaction.date.ToString("dd/MM/yyyy")} ||        ||  {transaction.amount}  ||   {balanceAmount}";
                }
            }

            Console.WriteLine(print);
            return print;
        }
    }
}

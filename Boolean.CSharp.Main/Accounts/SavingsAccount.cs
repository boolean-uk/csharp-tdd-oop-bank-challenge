using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : IAccount
    {
        public AccountType Type { get; } = AccountType.Savings;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public bool Deposit(decimal amount)
        {
            if (amount < 0)
                return false;

            Transaction transaction = new Transaction(amount, TransactionType.Deposit, GetBalance() + amount);
            Transactions.Add(transaction);

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if ((GetBalance() - amount) < 0) //Not enough money in account
                return false;


            Transaction transaction = new Transaction(amount, TransactionType.Withdraw, GetBalance() - amount);
            Transactions.Add(transaction);

            return true;
        }

        public void GenerateStatement()
        {
            Console.WriteLine("{0,-12} || {1, -8} || {2, -8} || {3, -8}",
                    "date",
                    "credit",
                    "debit",
                    "balance"
                );

            foreach (var transaction in Transactions)
            {
                decimal? credit = null;
                decimal? debit = null;

                switch (transaction.Type)
                {
                    case (TransactionType.Deposit):
                        credit = transaction.Amount;
                        break;
                    case (TransactionType.Withdraw):
                        debit = transaction.Amount;
                        break;
                }

                Console.WriteLine("{0,-12} || {1, -8} || {2, -8} || {3, -8}",
                    transaction.FormattedDate,
                    $"{credit}",
                    $"{debit}",
                    Math.Round(transaction.RemainingBalance, 2)
                );
            }
        }

        public decimal GetBalance()
        {

            decimal deposit = Transactions.Where(x => x.Type == TransactionType.Deposit).Sum(x => x.Amount);
            decimal withdraw = Transactions.Where(x => x.Type == TransactionType.Withdraw).Sum(x => x.Amount);

            decimal balance = deposit - withdraw;

            return balance;
        }
    }
}

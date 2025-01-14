using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : IAccount
    {
        public string AccountNumber { get; set; }

        // private decimal _balance { get; set; }

        // public decimal Balance { get { return _balance; } }

        public AccountType Type { get; } = AccountType.Current;

        public List<Transaction> Transaction { get; set; } = new List<Transaction>();


        public CurrentAccount(string accountNumber)
        {

            AccountNumber = accountNumber;

        }


        public bool deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            _balance += amount;

            Transaction transaction = new Transaction(amount, TransactionType.Deposit, _balance);
            Transaction.Add(transaction);
            return true;


        }


        public bool withdraw(decimal amount)
        {
            if (amount <= 0 || amount > _balance)
            {
                return false;

            }
            _balance -= amount;
            Transaction transaction = new Transaction(amount, TransactionType.Withdraw, _balance);
            Transaction.Add(transaction);
            return true;
        }


        public void GenerateStatement()
        {
            Console.WriteLine("{0, -12} || {1,-8} || {2,-8} || {3,-8} ",
                "Date", "Credit", "Debit", "Balance");

            foreach (var transaction in Transaction.OrderByDescending(t => t.Date))
            {
                decimal? credit = null;
                decimal? debit = null;

                switch (transaction.Type)
                {
                    case (TransactionType.Withdraw):
                        debit = transaction.Amount;
                        break;
                    case (TransactionType.Deposit):
                        credit = transaction.Amount;
                        break;
                }

                Console.WriteLine("{0, -12:dd/MM/yyyy} || {1, -8:F2} || {2, -8:F2} || {3, -8:F2}",
                    transaction.Date.ToString("dd/MM/yyyy"),
                    $"{credit}",
                    $"{debit}",
                    transaction.BalanceAfter);

            }
        }
        public decimal getBalance()
        {

        }
    }
}
                
        
           
                
                
            
                
                
            



        
    

        

        
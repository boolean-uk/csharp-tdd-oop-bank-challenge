using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Objects
{
    public class Account
    {
        private int _id;
        private string _accountName;
        private string _accountType;
        //Balance parameter is not needed, but is still here for running tests more simply
        private double _balance;
        private Branch _accountBranch;
        private BankStatement _accountStatement = new BankStatement();

        public Account(string accountName, Branch accountBranch)
        {
            _id += 1;
            _accountName = accountName;
            _accountBranch = accountBranch;
            _balance = 0;
            _accountType = "";
        }

        
        public int Id { get { return _id; } set { _id = value; } }
        public string AccountName { get { return _accountName; } set { _accountName = value; } }
        public string AccountType { get { return _accountType; } set { _accountType = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
        public Branch AccountBranch { get { return _accountBranch; } set { _accountBranch = value; } }
        public BankStatement AccountStatement { get { return _accountStatement; } set { _accountStatement = value; } }

        public void Deposit(double amount)
        {
            double oldBalance = Balance;
            Console.WriteLine("You have deposited " + amount);
            Balance += amount;
            Console.WriteLine("You now have " + Balance + " in your account");
            Deposit transcation = new Deposit(TransactionStatus.Success, amount, Balance, oldBalance);
            AccountStatement.Transactions.Add(transcation);
        }


        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                double oldBalance = Balance;
                Console.WriteLine("You have withdrawn " + amount);
                Balance -= amount;
                Console.WriteLine("You now have " + Balance + " left in your account");
                Withdraw transaction = new Withdraw(TransactionStatus.Success, amount, Balance, oldBalance);
                AccountStatement.Transactions.Add(transaction);
            }
            else
            {
                Console.WriteLine("Requests over draft for " + amount);
                if (RequestOverDraft())
                {
                    Console.WriteLine("Request for over draft has been accepted");
                    double oldBalance = Balance;
                    Console.WriteLine("You have withdrawn " + amount);
                    Balance -= amount;
                    Console.WriteLine("You now have " + Balance + " left in your account");
                    Overdraft transaction = new Overdraft(TransactionStatus.Success, amount, Balance, oldBalance);
                    AccountStatement.Transactions.Add(transaction);
                    AccountStatement.OverdraftCount++;
                }
                else if(!RequestOverDraft()){
                    Console.WriteLine("Request for overdraft has been rejected");                    
                }
            }
        }

        public void PrintBankStatement()
        {
            Console.WriteLine("date       || credit  || debit  || balance");
            foreach(var transaction in AccountStatement.Transactions)
            {
                if(transaction.Type == TransactionType.Deposit)
                {
                    Console.WriteLine($"{transaction.Date} || {transaction.Amount} ||        || {transaction.NewBalance}");

                } else if (transaction.Type == TransactionType.Withdraw)
                {
                    Console.WriteLine($"{transaction.Date} ||         || {transaction.Amount} || {transaction.NewBalance}");
                }
            }

        }

        public bool RequestOverDraft()
        {
            bool result = false;
            if (AccountStatement.OverdraftCount > 2)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Boolean.CSharp.Main
{
    public abstract class Account(Branch branch)
    {
        private readonly Transaction _transaction;
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public Branch Branch = branch;
        public bool OverdraftActive { get; set; } = false;
        public decimal BalanceCapacity { get; set; }
        public virtual AccountType AccountType { get; }
        public Transaction Transaction { get { return _transaction; } set { value = _transaction; } }
        public List<Transaction> Transactions { get { return _transactions; } set { value = _transactions; } }

     
        public decimal GetBalance() { 
            decimal deposit = Transactions.Where(t => t.TransactionType == TransactionType.Deposit).Sum(t => t.Amount);
            decimal withdraw = Transactions.Where(t => t.TransactionType == TransactionType.Withdraw).Sum(t => t.Amount);

            decimal balance = deposit - withdraw;
            return balance;
        }

        public bool Deposit(decimal amount, TransactionType transactionType)
        { 
            if (amount > 0)
            {
                Transaction transaction = new Transaction(amount, TransactionType.Deposit, GetBalance() + amount);
                Transactions.Add(transaction);
                return true;
            }

            return false;
        }


        public bool Withdraw(decimal amount, TransactionType transactionType)
        {
            if ((GetBalance() - amount) > BalanceCapacity)
            {
                Transaction transaction = new Transaction(amount, TransactionType.Withdraw, GetBalance() - amount);
                Transactions.Add(transaction);
                return true;
            }
            return false;
           
        }

        public void GenerateBankStatement()
        {
            Console.WriteLine("{0,-10} || {1,-6} || {2,-6} || {3,-6}",
                    "date",
                   "credit",
                   "debit",
                   "balance"
             );

            foreach (Transaction transaction in Transactions.OrderByDescending(x => x.Date))
            {
                decimal credit = 0;
                decimal debit = 0;

                if (transaction.TransactionType == TransactionType.Deposit)
                {
                    credit = transaction.Amount;
                }
                else if (transaction.TransactionType == TransactionType.Withdraw)
                {
                    debit = transaction.Amount;
                }

                Console.WriteLine("{0,-10} || {1,-6} || {2,-6} || {3,-6}",
                    transaction.Date,
                    credit,
                    debit,
                    transaction.Balance
                );

            }
        }

        private string FormatBankStatement()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("date || credit || debit || balance");

            foreach (var transaction in Transactions)
            {
                decimal credit = 0;
                decimal debit = 0;

                if (transaction.TransactionType == TransactionType.Deposit)
                {
                    credit = transaction.Amount;
                }
                else if (transaction.TransactionType == TransactionType.Withdraw)
                {
                    debit = transaction.Amount;
                }

                sb.AppendLine($"{transaction.Date} || {credit} || {debit} || {GetBalance()}");
            }

            return sb.ToString();
        }

        public void SendBankStatement()
        {
            var accountsid = "{accountaid}";
            var authtoken = "{authtoken}";

            TwilioClient.Init(accountsid, authtoken);

            var message = MessageResource.Create(
                    body: FormatBankStatement(),
                    from: new Twilio.Types.PhoneNumber("+12568889449"),
                    to: new Twilio.Types.PhoneNumber("+4741088332")
            );


        }

    }
}
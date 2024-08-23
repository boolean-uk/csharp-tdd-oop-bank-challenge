using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public bool OverdraftRequestIsActive { get; set; } = false;
        public decimal BalanceLimit { get; set; } = 0;
        public AccountType Type { get; } = AccountType.Current;

        public Branch Branch { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CurrentAccount(Branch branch)
        {
            Branch = branch;
        }
  
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
           if ((GetBalance() - amount) < BalanceLimit) //Not enough money in account
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
                    case(TransactionType.Deposit):
                        credit = transaction.Amount;
                        break;
                    case(TransactionType.Withdraw):
                        debit = transaction.Amount;
                        break;
                }

                Console.WriteLine("{0,-12} || {1, -8} || {2, -8} || {3, -8}",
                    transaction.FormattedDate,
                    $"{credit}",
                    $"{debit}",
                    Math.Round(transaction.RemainingBalance,2)
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

        public void TextBankStatement()
        {
            var accountSid = "[accountSid]"; //insert when testing
            var authToken = "[authToken]"; //insert when testing
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
            new PhoneNumber("+4741424344")); //insert your own number
            messageOptions.From = new PhoneNumber("+15005550006"); //insert twilio number 
            messageOptions.Body = FormatMessage();


            var message = MessageResource.Create(messageOptions);
        }

        private string FormatMessage()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("date || credit || debit || balance");

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

                sb.AppendLine($"{transaction.FormattedDate} || {credit} || {debit} || {Math.Round(transaction.RemainingBalance, 2)}");
            }

            return sb.ToString();
        }
    }
}

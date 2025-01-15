using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public double balance { get; set; } = 0;
        public Branch branch { get; set; }
        public ICollection<Transactions> _transactions = new List<Transactions>(); 
        public ICollection<Overdraft> _requests = new List<Overdraft>();

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
                Console.WriteLine("Your balance is to low, change amount OR ask for overdraft!");
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

        public bool requestOverdraft(double amount)
        {
            if (getBalance() > amount)
            {
                Console.WriteLine("Your balance is to high to ask for an overdraft!");
                return false;
            }

            Transactions transactions = new Transactions(amount, DateTime.Now, TransactionType.DEBIT);

            Overdraft overdraft = new Overdraft(this, amount, Answer.DECLINED, transactions);

            _requests.Add(overdraft);

            return true;
        }

        public void phoneMessage()
        {
            string accountSid = "SID";
            string authToken = "AUTH_TOKEN";

            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new Twilio.Types.PhoneNumber("+4790414810"));
            messageOptions.From = new Twilio.Types.PhoneNumber("+12562724075");
            messageOptions.Body = bankStatement();

            var message = MessageResource.Create(messageOptions);

           
            Console.WriteLine(message.Body);
        }
    }
}

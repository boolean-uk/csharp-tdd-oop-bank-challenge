using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private List<Transactions> _transactions { get; set; }

        private int _accountNumber { get; set; }

        private Customer _customer { get; set; }
        
        private string _accountBranch { get; set; }

        public string accountBranch { get { return _accountBranch; } }
        public int accountNumber { get { return _accountNumber; } }
        public List<Transactions> transactions { get { return _transactions; }}
        public Customer customer { get { return _customer; } }

        public Account(Customer customer, string branch, int accountNumber)
        {
            _transactions = new List<Transactions>();
            _accountNumber = accountNumber;
            _accountBranch = branch;
            _customer = customer;
        }
        public string getBranch()
        {
            return accountBranch;
        }

        public float getBalance()
        {
            return transactions.Sum(x => x.Amount); 
        }

        public virtual bool transaction(Transactions transaction)
        {
            if(getBalance() + transaction.Amount > 0f)
            {
                Console.WriteLine(getBalance() + transaction.Amount > 0f);
                _transactions.Add(transaction);
                return true;
            }
            return false;
        }

        public List<Transactions> getTransactionHistory() 
        { 
            return transactions; 
        }
        public bool sendTransaction()
        {
            string msg = transactions[transactions.Count - 1].getTransaction();
            var accountSid = "Fill in here";
            var authToken = "Fill in here";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("+4741583032"));
            messageOptions.From = new PhoneNumber("+12564877399");
            messageOptions.Body = msg;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
            return true;
        }
        public void addTransaction(Transactions trans)
        {
            _transactions.Add(trans);
        }
    }
}

using Boolean.CSharp.Main.CustomerAccounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        private string _bankName;

        public Core(string name)
        {
            bankName = name;
        }

        public bool makeADeposit(Users.User user, Account account, int amount)
        {
            if (user is Users.Customer)
            {
                if (account is CurrentAccount)
                {
                    ((Users.Customer)user).account1.deposit(amount);
                    return true;
                }
                if (account is SavingsAccount)
                {
                    ((Users.Customer)user).account2.deposit(amount);
                    return true;
                }
            }
            return false;
        }

        public bool makeAWithdraw(Users.User user, Account account, int amount)
        {
            if (user is Users.Customer)
            {
                if (account is CurrentAccount)
                {
                    ((Users.Customer)user).account1.withdraw(amount);
                    return true;
                }
                if (account is SavingsAccount)
                {
                    ((Users.Customer)user).account2.withdraw(amount);
                    return true;
                }
            }
            return false;
        }

        public List<Transaction.Transaction> printBankStatement(Users.User user, Account account)
        {
            List<Transaction.Transaction> list = new List<Transaction.Transaction>();
            if (user is Users.Customer)
            {
                if (account is CurrentAccount)
                {
                    list = ((Users.Customer)user).account1.printBankStatement();
                }
                if (account is SavingsAccount)
                {
                    list = ((Users.Customer)user).account2.printBankStatement();
                }
            }
            return list;
        }

        public void send(string message1)
        {
            string accountSid = "ACd91a7b12d75c0a5162b3316b913cbb65";
            string authToken = "dca504a42d0ec819d89b95bf69b1492b";
            TwilioClient.Init(accountSid, authToken);


            var message = MessageResource.Create(
                body: message1,
                from: new Twilio.Types.PhoneNumber("+12544015317"), // virtual Twilio number
                to: new Twilio.Types.PhoneNumber("+306949873855"));//myNumber
        }



        public string bankName { get { return _bankName; } set { _bankName = value; } }
    }
}

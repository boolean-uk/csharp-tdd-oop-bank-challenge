/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public class SMSService
    {
        private string _accountSid;
        private string _authToken;

        public SMSService()
        {
            _accountSid = "AccountSID";
            _authToken = "AuthToken";
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendStatement(IAccount account, string phoneNumber)
        {
            string message = "Dear " + account.Owner.Name + "\n";
            message += "Here is your bank statement for your account: \n\n"; 
            message += ("{0,10} || {1, 11} || {2,11} || {3,11} ", "Date", "Deposit", "Withdraw", "Balance");
            message += "\n";
            foreach (Transaction transaction in account.Transactions.OrderByDescending(t => t.Time))
            {
                message += ("{0,10} || £{1,10} || £{2,10} || £{3, 10}",
                    transaction.Time.Date.ToShortDateString(),
                    transaction.Type == TransactionType.Deposit ? Math.Round(transaction.Amount, 2) : 0,
                    transaction.Type == TransactionType.Withdrawal ? Math.Round(transaction.Amount, 2) : 0,
                    Math.Round(transaction.NewBalance, 2));
                message += "\n";
            }


            var SMS = MessageResource.Create
            {
            body: message;
            from: new Twilio.Types.PhoneNumber("Banks Phone number");
            to: new Twilio.Types.PhoneNumber(phoneNumber);
            };

            Console.WriteLine(SMS.Sid);
        }

    }
}*/
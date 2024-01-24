using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        public Branch Branch { get; set; }
        public bool OverdraftApproved { get; set; } = false;

        private List<ITransaction> _transactions = new List<ITransaction>();

        public void AddTransaction(ITransaction transaction)
        {
            if ((this.GetBalance()+transaction.GetDetails().Item2)<0 && !this.OverdraftApproved)
            { 
                Console.WriteLine("You do not have overdraft permission"); 
            }
            else
            {
                _transactions.Add(transaction);
                transaction.SetBalance(this.GetBalance());
            }
        }

        public string GenerateBankStatement()
        {
            if (_transactions == null || !_transactions.Any())
                return "No transactions available.";

            StringBuilder statement = new StringBuilder();
            var orderedTransactions = _transactions.OrderByDescending(t => t.GetDetails().Item1).ToList();

            // Placeholder for maximum column widths
            int maxDateLen = "date".Length, maxAmountLen = "amount".Length, maxBalanceLen = "balance".Length;

            foreach (var transaction in orderedTransactions)
            {
                var (date, amount, balance) = transaction.GetDetails();
                maxDateLen = Math.Max(maxDateLen, date.ToString().Length);
                maxAmountLen = Math.Max(maxAmountLen, $"{amount:0.00}".Length)+2;
                maxBalanceLen = Math.Max(maxBalanceLen, $"{balance:0.00}".Length);
            }

            string format = $"{{0,-{maxDateLen}}} || {{1,-{maxAmountLen}}} || {{2,-{maxBalanceLen}}}";

            statement.AppendLine(string.Format(format, "date", "amount", "balance"));

            foreach (var transaction in orderedTransactions)
            {
                var (date, amount, balance) = transaction.GetDetails();

                string dateString = date.ToString();
                string amountString = amount >= 0 ? $"{amount:0.00}  " : $"  {amount:0.00}";
                string balanceString = $"{balance:0.00}";

                statement.AppendLine(string.Format(format, dateString, amountString, balanceString));
            }
            string result = statement.ToString().TrimEnd();

            return result;
        }


        public double GetBalance()
        {
            double balance = 0;

            balance += (_transactions.Sum(t => t.GetDetails().Item2));

            return balance;
        }

        public void SendBankstatementSMS()
        {
            string bankStatement = this.GenerateBankStatement();

            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");


            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+4791125241"));
                messageOptions.From = new PhoneNumber("+12244123394");
                messageOptions.Body = bankStatement;

            var message = MessageResource.Create(messageOptions);

            Console.WriteLine(message.Sid);
        }
    }
}

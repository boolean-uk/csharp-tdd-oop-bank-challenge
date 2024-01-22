using Boolean.CSharp.Main.Accounts;
using Microsoft.Extensions.Configuration;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Models
{
    public class Customer
    {
        private readonly List<IAccount> _accounts = [];
        public void CreateAccount(IAccount account)
        {
            _accounts.Add(account);
        }

        public List<IAccount> GetAccounts()
        {
            return _accounts;
        }

        public int GetNumberOfAccounts()
        {
            return _accounts.Count;
        }

        public static void RequestOverdraft(Request request)
        {
            request.Account.Branch.Requests.Add(request);
        }

        public static void MessageStatements(IAccount account)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string accountSid = config["Twilio:Sid"]!;
            string authToken = config["Twilio:Token"]!;
            string phoneNumber = config["Private:phoneNumber"]!;

            TwilioClient.Init(accountSid, authToken);

            var statements = account.BankStatements;
            statements.Sort((a, b) => a.Date.CompareTo(b.Date));
            StringBuilder sb = new();
            sb.AppendLine($"{"Date",10}{"Credit",10}{"Debit",10}{"Balance",10}");
            foreach (var statement in statements)
            {
                sb.AppendLine(
                    $"{statement.Date,10:dd/MM/yyyy}" +
                    $"{statement.Credit,10:0.00}" +
                    $"{statement.Debit,10:0.00}" +
                    $"{statement.Balance,10:0.00}");
            }

            var message = MessageResource.Create(
                body: sb.ToString(),
                from: new Twilio.Types.PhoneNumber("+12029336384"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );

            Console.WriteLine(message.Sid);
        }
    }
}

using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account(IBranch branch, string name) : IAccount
    {
        public string Name { get; } = name;
        public double Balance { get { return _bankStatements.Last().Balance; } }

        public List<BankStatement> BankStatements { get { return _bankStatements; } }

        public IBranch Branch { get; } = branch;

        private readonly List<BankStatement> _bankStatements = [];

        public void Deposit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            GenerateBankStatements(amount);
        }

        public double Withdraw(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            if (amount > Balance)
            {
                throw new Exception("Can't withdraw more than the current balance!");
            }
            GenerateBankStatements(-amount);
            return amount;
        }

        public void GenerateBankStatements(double amount)
        {
            double balance = _bankStatements.Count == 0 ? 0 : Balance;
            BankStatement bankStatement = new(balance, amount);
            _bankStatements.Add(bankStatement);
        }

        public void PrintBankStatements()
        {
            var statements = _bankStatements;
            statements.Sort((a, b) => a.Date.CompareTo(b.Date));
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}",
                "Date", "Credit", "Debit", "Balance");
            foreach (var statement in statements)
            {
                Console.WriteLine("{0,10}{1,10}{2,10}{3,10}",
                    $"{statement.Date:dd/MM/yyyy}",
                    $"{statement.Credit:0.00}",
                    $"{statement.Debit:0.00}",
                    $"{statement.Balance:0.00}");
            }
        }

        public void MessageStatements()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string accountSid = config["Twilio:Sid"]!;
            string authToken = config["Twilio:Token"]!;
            string phoneNumber = config["Private:phoneNumber"]!;

            TwilioClient.Init(accountSid, authToken);

            var statements = BankStatements;
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

using Boolean.CSharp.Main.Acounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extensions
{
    public class Person
    {
        public string Name { get; set; }

        public Role Role { get; set; }

        private Bank Bank { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();

        public Person(string name, Role role, Bank? bank)
        {
            Name = name;
            Role = role;
            Bank = bank;
        }

        public void addAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void answerOverdraft(OverdraftRequest request)
        {
            if (this.Role != Role.MANAGER)
            {
                Console.WriteLine("You are not allowed to perform this action...");
                return;
            }
            if (Bank.EmergencyFund < request.Amount)
            {
                Console.WriteLine("Not enough funds left...");
                return;
            }
            Console.WriteLine("Request got accepted");
            request.Accept();
            Bank.EmergencyFund -= (request.Amount - request.Account.Balance);
            request.Account.RequestoToTransaction();
            request.Account.OverdraftRequests.Remove(request);

        }
    }
}

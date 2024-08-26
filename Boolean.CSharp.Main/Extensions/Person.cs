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

        public List<Account> Accounts { get; set; } = new List<Account>();

        public Person(string name, Role role)
        {
            Name = name;
            Role = role;
        }

        public void addAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void answerOverdraft(Person person, OverdraftRequest request)
        {
            if (person.Role != Role.CUSTOMER)
            {
                Console.WriteLine("You are not allowed to perform this action...");
                return;
            }
            Console.WriteLine("Request got accepted");
            request.Accept();

            request.Account.RequestoToTransaction();

        }
    }
}

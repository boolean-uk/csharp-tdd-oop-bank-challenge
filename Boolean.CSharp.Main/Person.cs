using Boolean.CSharp.Main.Acounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
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
    }
}

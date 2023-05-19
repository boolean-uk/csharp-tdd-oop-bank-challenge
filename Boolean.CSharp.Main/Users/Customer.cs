using Boolean.CSharp.Main.CustomerAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Customer : User, iAccount
    {
        public Customer(string name, string surname, string email, Account account1, Account account2)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.account1 = account1;
            this.account2 = account2;
        }
        public Account account1 { get; set; }
        public Account account2 { get; set; }
    }
}

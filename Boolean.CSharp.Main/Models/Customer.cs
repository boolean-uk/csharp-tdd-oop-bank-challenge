using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public Customer(string name)
        {
            Name = name;
            Accounts = new List<IAccount>();
            Id = Guid.NewGuid().ToString();
        }
        public IAccount CreateAccount(AccountType current, Branch branch, string accountName)
        {
            IAccount account;
            if (current == AccountType.Current)
            {
                account = new CurrentAccount(branch, accountName);
            }
            else
            {
                account = new SavingsAccount(branch, accountName);
            }

            Accounts.Add(account);
            return account;
        }
    }
}

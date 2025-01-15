using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class Customer : IPerson
    {
        private List<Account> _accounts;
        public List<Account> Accounts { get { return _accounts; } }

        public string Name { get; set; }
        public string Id { get; set; }

        public Customer(string id, string name) 
        { 
            _accounts = new List<Account>();
            Name = name;
            Id = id;
        }
        public void AddAccount(Account account)
        {
            if (Accounts.Contains(account)) return;
            _accounts.Add(account); 
        }
        public OverdraftRequest RequestOverdraft(CurrentAccount account, decimal amount)
        {
            OverdraftRequest overdraftRequest = new OverdraftRequest(account, amount);
            return overdraftRequest;
        }
    }
}
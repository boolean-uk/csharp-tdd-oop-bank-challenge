using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private string _name;
        private List<IAccount> _accounts = new List<IAccount>(); 

        public Customer(string name)
        {
            _name = name;
        }


        public IAccount CreateAccount(string accountType)
        {
            IAccount account = null;
            if (accountType == "Current")
            {
                account = new CurrentAccount();
            }
            else if (accountType == "Savings")
            {
                account = new SavingsAccount();
            }
            _accounts.Add(account);
            return account;


        }

        public OverdraftRequest SendOverdraftRequest(IAccount account, decimal amount)
        {

            return new OverdraftRequest(account, amount, "Pending"); 
        }


        public string Name { get; private set; }
        public List<IAccount> Accounts { get; private set; } = new List<IAccount>();


    }
}

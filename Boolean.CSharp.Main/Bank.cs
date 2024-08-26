using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<Customer> _customers;

        private Manager _manager;
        private int _runningIDs;

        public Bank(Manager m)
        {
            this._manager = m;
            this._customers = new List<Customer>();
            this._runningIDs = 0;
        }

        public bool AddCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public Customer FindCustomer(int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public BankAccount CreateAccount(Customer c, AccountType t)
        { 
            throw new NotImplementedException();
        }

        public List<Customer> Customers { get => this._customers; set => this._customers = value; }
        public Manager Manager { get => this._manager; set => this._manager = value; }
    }
}

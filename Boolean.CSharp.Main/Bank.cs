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
            if(!this._customers.Any(x => x.PhoneNumber == c.PhoneNumber))
            {
                this._customers.Add(c);
                return true;
            }
            return false;
            
        }

        public bool RemoveCustomer(Customer c)
        {
            if (this._customers.Any(x => x.PhoneNumber == c.PhoneNumber))
            {
                this._customers.Remove(c);
                return true;
            }
            return false;
        }

        public Customer FindCustomer(int phoneNumber)
        {
            return this._customers.Find(c => c.PhoneNumber == phoneNumber);
        }

        public BankAccount CreateAccount(Customer c, AccountType t, BankBranches b, string accountname)
        {
            if (t == AccountType.Current)
            {
                BankAccount account = new CurrentAccount(b, this._runningIDs, accountname, c);
                this._runningIDs++;
                c.AddBankAccount(account);
                return account;
            }
            else
            {
                BankAccount account = new SavingAccount(b, this._runningIDs, accountname, c);
                this._runningIDs++;
                c.AddBankAccount(account);
                return account;
            }
        }

        public List<Customer> Customers { get => this._customers; set => this._customers = value; }
        public Manager Manager { get => this._manager; set => this._manager = value; }
    }
}

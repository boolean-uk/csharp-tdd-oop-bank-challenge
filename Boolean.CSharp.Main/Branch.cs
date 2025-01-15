using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.AccountType;
using Boolean.CSharp.Test;

namespace Boolean.CSharp.Main
{
    public class Branch
    {
        public string branchName { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<IAccount> Accounts { get; set; }
        public Bank bank { get; set; }

        public Branch(string name, Bank bank)
        {
            this.CustomerList = new List<Customer>();
            this.Accounts = new List<IAccount>();
            this.bank = bank;
        }

        public IAccount CreateAccount(Customer customer, char type)
        {
            if (type == 's')
            {
                SavingsAccount newAccount = new SavingsAccount(customer);
                customer.accounts.Add(newAccount);
                Accounts.Add(newAccount);
                return newAccount;
            }
            else if (type == 'c')
            {
                CurrentAccount newAccount = new CurrentAccount(customer);
                customer.accounts.Add(newAccount);
                Accounts.Add(newAccount);
                return newAccount;

            }
            else
            {
                throw new InvalidDataException("Type (char) is not valid");
            }
        }


    }
}

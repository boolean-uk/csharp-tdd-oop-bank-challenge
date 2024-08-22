using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Model
    {
        private Bank _bank;


        public Model()
        {
            this._bank = new Bank();
        }

        internal bool createPerson(bool isCustomer, IPerson person)
        {
            if (person != null && person is Customer)
            {
                _bank.addNewCustomer(person);
                return true;
            }
            return false;
        }

        public bool createBankAccount(Customer person)
        {
            if (person != null && person is Customer && person.ID == -1) //id == null if person does not have bank account, id is given by bank
            {
                _bank.createBankAccount(person);
                return true;
            }
            return false;
        }

        internal BankAccount GetBankAccount(int customerID)
        {
            return _bank.getBankAccount(customerID);
        }

        internal List<Customer> getCustomers()
        {
            return _bank.getCustomers();
        }
    }
}

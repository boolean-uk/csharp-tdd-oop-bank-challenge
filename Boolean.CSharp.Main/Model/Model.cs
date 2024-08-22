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

        internal bool createPerson(IPerson person)
        {
            if (person == null && person is IPerson)
            {
                _bank.addNewCustomer(person);
                return true;
            }
            return false;
        }

        public bool createBankAccount(IPerson person)
        {
            if (person == null)
            {
            }
            return false;
        }

        private bool checkDuplicateID(IPerson person)
        {




            return false;
        }

        internal List<Customer> getCustomers()
        {
            return _bank.getCustomers();
        }
    }
}

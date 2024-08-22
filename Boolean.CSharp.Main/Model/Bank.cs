using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Bank
    {
        private List<Engineer> _engineerList;
        private List<Customer> _customerList;
        private List<BankAccount> _bankAccountList;

        public Bank()
        {
            this._engineerList = new List<Engineer>();
            this._bankAccountList = new List<BankAccount>();
            this._customerList = new List<Customer>();
        }

        internal List<Customer> customers { get; }

        internal void addNewCustomer(IPerson person)
        {
            _customerList.Add((Customer)person);
        }

        internal List<Customer> getCustomers()
        {
            return _customerList;
        }
    }
}

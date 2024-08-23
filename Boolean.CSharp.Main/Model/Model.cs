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

        public bool createBankAccount(Customer person, Enum branch)
        {
            if (person != null && person is Customer && person.ID == -1) //id == null if person does not have bank account, id is given by bank
            {
                _bank.createBankAccount(person, branch);
                return true;
            }
            return false;
        }

        internal BankAccount getBankAccount(int customerID)
        {
            return _bank.getBankAccount(customerID);
        }

        internal List<Customer> getCustomers()
        {
            return _bank.getCustomers();
        }

        internal bool depositMoneyIntoTransactionalAccount(float amount, int customerID)
        {
            return _bank.depositMoneyIntoTransactionalAccount(amount, customerID);
        }
        internal bool depositMoneyIntoSavingsAccount(float amount, int customerID)
        {
            return _bank.depositMoneyIntoSavingsAccount(amount, customerID);
        }
        internal bool withdrawMoneyFromTransactionalAccount(float amount, int customerID)
        {
            //dont really care where the money goes, just check that it actually withdraws
            return _bank.withdrawMoneyFromTransactionalAccount(amount,customerID);
            
        }
        internal bool withdrawMoneyFromSavingsAccount(float amount, int customerID)
        {
            return _bank.withdrawMoneyFromSavingsAccount(amount, customerID);
        }

        internal bool requestOverdraft(int customerID, float amount, string reason)
        {
            return _bank.requestOverdraft(customerID, amount, reason);
        }

        internal List<OverdraftRequest> getOverdraftRequests()
        {
            return _bank.getOverdraftRequests();
        }

        internal void approveOverdraftRequest(OverdraftRequest overdraftRequest)
        {
            _bank.approveOverdraftRequest(overdraftRequest);
        }
    }
}

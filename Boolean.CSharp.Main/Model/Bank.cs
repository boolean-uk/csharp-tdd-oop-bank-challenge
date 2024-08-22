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
        private int _nextID = 1;

        public Bank()
        {
            this._engineerList = new List<Engineer>();
            this._bankAccountList = new List<BankAccount>();
            this._customerList = new List<Customer>();
        }

        internal List<Customer> customers { get; }

        internal void addNewCustomer(IPerson person)
        {
            _customerList.Add(new Customer(person.FirstName, person.LastName, person.PhoneNumber, person.CashOnHand));
        }

        internal void createBankAccount(Customer person)
        {
            person.ID = this._nextID++;
            _bankAccountList.Add(new BankAccount(person.ID));
        }

        internal List<Customer> getCustomers()
        {
            return _customerList;
        }

        internal bool depositMoneyIntoTransactionalAccount(float amount, int customerID)
        {
            BankAccount bankAccount = _bankAccountList.Find(account => account.getBankId() == customerID);
            if (bankAccount != null)
            {
                bankAccount.depositMoneyToTransactionalAccount(amount);
                return true;
            }
            return false;
        }
        internal bool depositMoneyIntoSavingsAccount(float amount, int customerID)
        {
            BankAccount bankAccount = _bankAccountList.Find(account => account.getBankId() == customerID);
            if (bankAccount != null)
            {
                bankAccount.depositMoneyToSavingsAccount(amount);
                return true;
            }
            return false;
        }
        internal bool withdrawMoneyFromTransactionalAccount(float amount, int customerID)
        {
            BankAccount bankAccount = _bankAccountList.Find(account => account.getBankId() == customerID);
            if (bankAccount != null)
            {
                bankAccount.withdrawMoneyFromTransactionalAccount(amount);
                return true;
            }
            return false;
        }
        internal bool withdrawMoneyFromSavingsAccount(float amount, int customerID)
        {
            BankAccount bankAccount = _bankAccountList.Find(account => account.getBankId() == customerID);
            if (bankAccount != null)
            {
                bankAccount.withdrawMoneyFromSavingsAccount(amount);
                return true;
            }
            return false;
        }

        internal BankAccount getBankAccount(int customerID) { return _bankAccountList.Find(account => account.getBankId() == customerID); }
    }
}

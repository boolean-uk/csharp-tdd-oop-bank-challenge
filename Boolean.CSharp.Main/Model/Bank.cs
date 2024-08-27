﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Bank
    {
        private List<Customer> _customerList;
        private List<BankAccount> _bankAccountList;
        private List<OverdraftRequest> _overdraftRequestList;
        private int _nextID = 1;

        internal enum Branch
        {
            HR,
            Economy,
            IT,
            Security,
            Other
        }

        internal Bank()
        {
            this._bankAccountList = new List<BankAccount>();
            this._customerList = new List<Customer>();
            this._overdraftRequestList = new List<OverdraftRequest>();
        }

        internal List<Customer> customers { get; }

        internal void addNewCustomer(IPerson person)
        {
            _customerList.Add(new Customer(person.FirstName, person.LastName, person.PhoneNumber, person.CashOnHand));
        }

        internal void createBankAccount(Customer person, Enum branch)
        {

            switch (branch)
            {
                case Branch.HR:

                    person.ID = this._nextID++;
                    _bankAccountList.Add(new BankAccount(person.ID, Branch.HR));
                    break;
                case Branch.Economy:
                    person.ID = this._nextID++;
                    _bankAccountList.Add(new BankAccount(person.ID, Branch.Economy));
                    break;
                case Branch.IT:
                    person.ID = this._nextID++;
                    _bankAccountList.Add(new BankAccount(person.ID, Branch.IT));
                    break;
                case Branch.Security:
                    person.ID = this._nextID++;
                    _bankAccountList.Add(new BankAccount(person.ID, Branch.Security));
                    break;
                case Branch.Other:
                    person.ID = this._nextID++;
                    _bankAccountList.Add(new BankAccount(person.ID, Branch.Other));
                    break;
                default:
                    person.ID = this._nextID++;
                    _bankAccountList.Add(new BankAccount(person.ID));
                    break;
            }


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
            if (bankAccount != null && bankAccount.getTransactionsAccountBalance() >= amount)
            {
                bankAccount.withdrawMoneyFromTransactionalAccount(amount);
                return true;
            }
            return false;
        }
        internal bool withdrawMoneyFromSavingsAccount(float amount, int customerID)
        {
            BankAccount bankAccount = _bankAccountList.Find(account => account.getBankId() == customerID);
            if (bankAccount != null && bankAccount.getSavingsAccountBalance() >= amount)
            {
                bankAccount.withdrawMoneyFromSavingsAccount(amount);
                return true;
            }
            return false;
        }

        internal BankAccount getBankAccount(int customerID) { return _bankAccountList.Find(account => account.getBankId() == customerID); }

        internal bool requestOverdraft(int customerID, float amount, string reason)
        {
            if (_customerList.Any(customer => customer.ID == customerID))
            {
                _overdraftRequestList.Add(new OverdraftRequest(customerID, amount, reason));
                return true;
            }
            return false;
        }

        internal List<OverdraftRequest> getOverdraftRequests()
        {
            return _overdraftRequestList;
        }

        internal void approveOverdraftRequest(OverdraftRequest overdraftRequest)
        {
            if (_overdraftRequestList.Find(request => request == overdraftRequest) != null)
            {
                overdraftRequest.approve();
            }
        }
    }
}

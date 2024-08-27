using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank : IManager, ICustomer
    {
        private List<CurrentAccount> _overDraftRequests;
        public List<CurrentAccount> requests { get { return _overDraftRequests; } }

        private List<Account> _allBankAccount;

        private int _accountNumber;

        public Bank()
        {
            _overDraftRequests = new List<CurrentAccount>();
            _accountNumber = 0;
            _allBankAccount = new List<Account>();
        }
        public void approveRequest(CurrentAccount ca)
        {
            ca.overDraft = true;
            _overDraftRequests.Remove(ca);
        }

        public Account createCurrentAccount(Customer customer, string branch)
        {
            _accountNumber++;
            Account act = new CurrentAccount(customer, branch, _accountNumber);
            _allBankAccount.Add(act);
            return act;
        }

        public Account createSavingsAccount(Customer customer, string branch)
        {
            _accountNumber++;
            Account act =  new SavingsAccount(customer, branch, _accountNumber);
            _allBankAccount.Add(act );
            return act;
        }

        public void rejectRequest(CurrentAccount ca)
        {
            ca.overDraft = false;
            _overDraftRequests.Remove(ca);
        }

        public void requestsOverDraft(Account ca)
        {
            _overDraftRequests.Add((CurrentAccount)ca);
        }
    }
}

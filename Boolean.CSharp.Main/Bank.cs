using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<CurrentAccount> _overDraftRequests;
        public List<CurrentAccount> requests { get { return _overDraftRequests; } }

        public void approveRequest(CurrentAccount ca)
        {
            throw new NotImplementedException();
        }

        public Account createCurrentAccount(Customer customer, string branch)
        {
            throw new NotImplementedException();
        }

        public Account createSavingsAccount(Customer customer, string _branchname)
        {
            throw new NotImplementedException();
        }

        public void rejectRequest(CurrentAccount ca)
        {
            throw new NotImplementedException();
        }
    }
}

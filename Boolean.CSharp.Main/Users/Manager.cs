using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Manager : IEmployee
    {
        private string _name;
        private List<IAccount> _accounts = new List<IAccount>();
        private IBankBranch _branch;
        private List<IOverdraftRequest> _overdraftRequests = new List<IOverdraftRequest>();

        public Manager(string name)
        {
            _name = name;
        }

        public void AddOverdraftRequest()
        {
            throw new NotImplementedException();
        }

        public void EvaluateOverdraftRequests(bool approval)
        {
            throw new NotImplementedException();
        }

        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(_accounts);
        }

        public string GetName()
        {
            return _name;
        }

        public bool RegisterWithBankBranch(IBankBranch branch)
        {
            _branch = branch;
            return branch.AddEmployeeToBranch(this);
        }

        public string ShowOldestOverdraftRequest()
        {
            throw new NotImplementedException();
        }
    }
}

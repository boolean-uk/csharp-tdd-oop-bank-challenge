using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
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

        public Manager(string name)
        {
            _name = name;
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
    }
}

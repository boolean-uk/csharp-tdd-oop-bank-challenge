using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public abstract class Customer(string name, DateTime DoB) : IUser
    {
        private List<IAccount> _associatedAccounts = new List<IAccount>();
        private string _name = name;
        private IBankBranch _branch;
        private DateTime _birthDate = DoB;
        private DateTime _lastLogin = DateTime.Now;

        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(this._associatedAccounts);
        }

        public void RegisterAccount(IAccount account) 
        {
            _associatedAccounts.Add(account);
        }

        public List<IAccount> GetAssociatedAccounts() 
        {
            return new List<IAccount>(_associatedAccounts);
        }

        public string GetName()
        {
            return _name;
        }

        public bool OpenNewAccount(AccountType accountType) 
        {
            IAccount newAcc;
            int val1;
            int val2;
            val1 = _associatedAccounts.Count;
            if (accountType == AccountType.General)
            {
                newAcc = new GeneralAccount(this);
            }
            else 
            {
                newAcc = new SavingsAccount(this);
            }
            val2 = _associatedAccounts.Count;
            return val1 < val2;
        }

        public void LogIn() 
        {
            _lastLogin = DateTime.Now;
        }

        public bool RegisterWithBankBranch(IBankBranch branch)
        {
            _branch = branch;
            return branch.AddUserToBranch(this);
        }
    }
}

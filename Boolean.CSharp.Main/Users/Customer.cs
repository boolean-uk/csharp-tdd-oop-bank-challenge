using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Transactions;
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

        /// <inheritdoc />
        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(this._associatedAccounts);
        }

        /// <summary>
        /// Add a provided account to the list of IAccount's associated with this Customer object
        /// </summary>
        /// <param name="account"> IAccount - The account to associate with the Customer</param>
        public void RegisterAccount(IAccount account) 
        {
            _associatedAccounts.Add(account);
        }

        /// <inheritdoc />
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// Attempt to open a new account
        /// </summary>
        /// <param name="accountType">AccountType - a enum value contained within the AccountType category</param>
        /// <returns>bool - True if the new account was successfully created, false otherwise</returns>
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

        /// <summary>
        /// Log into the Customer account, resets the _lastLogin flag.
        /// </summary>
        public void LogIn() 
        {
            _lastLogin = DateTime.Now;
        }

        /// <inheritdoc />
        public bool RegisterWithBankBranch(IBankBranch branch)
        {
            _branch = branch;
            return branch.AddUserToBranch(this);
        }

        /// <summary>
        /// Submit a request to change the overdraft limit on a specified and provided IAccount object
        /// </summary>
        /// <param name="amount"> decimal - the desired new overdraft limit </param>
        /// <param name="account"> IAccount - the account that the Customer wishes to change the overdraft limit for </param>
        public void RequestOverdraft(decimal amount, IAccount account) 
        {
            if (_branch == null)
            {
                Console.WriteLine("This customer is not associated with any branch, and can thus not ask for new overdraft limit");
            }
            else 
            {
                IOverdraftRequest request = new OverdraftRequestFixedAmount(this, amount, account);
                _branch.AssignOverdraftRequest(request);
            }
        }
    }
}

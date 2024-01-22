using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class AccountTest
    {
        private Guid _accountId;
        private double _balance = 0;
        private string _branch;
        
        private List<Account> _accounts = new List<Account>();

        public AccountTest(string Branch, Customer customer) 
        {
            this.AccountId = Guid.NewGuid();
            this._branch = Branch;
            
        }
        public Guid AccountId { get { return _accountId; } set { _accountId = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
        public string Branch { get { return _branch; } set { _branch = value; } }
    }
}

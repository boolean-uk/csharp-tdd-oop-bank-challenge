using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{

    public class SavingsAccount : Account
    {

        private User _user;
        private Branch _branch;

        public SavingsAccount(User user, Branch branch = Branch.Oslo)
        {
            _user = user;
            _branch = branch;
        }

        public User User { get { return _user; } }
        public Branch Branch { get { return _branch; } }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        private User _user;
        private Branch _branch;

        public CurrentAccount(User user, Branch branch = Branch.Oslo)
        {
            _user = user;
            _branch = branch;
        }

        public User User { get { return _user; } }
    }   
}

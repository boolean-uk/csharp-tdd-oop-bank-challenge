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

        public SavingsAccount(User user)
        {
            _user = user;
        }

        public User User { get { return _user; } }
    }
}

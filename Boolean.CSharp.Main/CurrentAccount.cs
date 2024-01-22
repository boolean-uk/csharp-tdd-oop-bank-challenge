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

        public CurrentAccount(string accountName, User user)
        {
            _user = user;
        }

        public User User { get { return _user; } }
    }   
}

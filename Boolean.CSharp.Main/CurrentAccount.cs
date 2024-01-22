using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(User user) : base(user)
        {
        }

        public CurrentAccount(User user, double balance) : base(user, balance)
        {
        }
    }
}
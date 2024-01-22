using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(User user) : base(user)
        {
        }

        public SavingsAccount(User user, double balance) : base(user, balance)
        {
        }
    }
}
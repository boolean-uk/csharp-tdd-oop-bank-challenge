using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public abstract class AAccount
    {
        public double _savings { get; private set; }
        
        public AAccount()
        {
            _savings = 0;
        }


        public bool Deposit(double amount)
        {
            _savings += amount;
            return true;
        }

        public bool Withdraw(double amount)
        {
            _savings -= amount;
            return true;
        }
    }
}

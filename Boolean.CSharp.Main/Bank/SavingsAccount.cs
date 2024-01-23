using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public class SavingsAccount : Account
    {
        private double _balance { get; set; }

        public SavingsAccount(double balance) : base(balance, new List<ITransaction>())
        {
            _balance = balance;
        }

        
    }
}

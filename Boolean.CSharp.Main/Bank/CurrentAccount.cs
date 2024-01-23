using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public class CurrentAccount : Account
    {
        private double _balance { get; set;  }

        public CurrentAccount(double balance) : base(balance, new List<ITransaction>())
        {            
            _balance = balance;
        }
    }
}

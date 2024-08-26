using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public double balance { get; set; } = 0;
        public ICollection<Transactions> _transactions { get { return _transactions; } }

        public double getBalance()
        {
            return this.balance;
        }
    }
}

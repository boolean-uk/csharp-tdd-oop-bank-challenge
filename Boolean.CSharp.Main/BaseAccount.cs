using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class BaseAccount
    {
        private float _money;
        public float Money { get { return _money; } }
        public bool Deposit(float amount)
        {
            throw new NotImplementedException();
        }
        public bool Withdraw(float amount)
        {
            throw new NotImplementedException();
        }

    }
}

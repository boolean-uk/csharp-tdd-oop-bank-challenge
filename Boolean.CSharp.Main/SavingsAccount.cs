using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        private bool _locked;

        public SavingsAccount()
        {
            _locked = false;
        }

        public void LockAccount()
        {

        }

        public void UnlockAccount()
        {

        }

        public bool Locked { get { return _locked; } }
    }
}

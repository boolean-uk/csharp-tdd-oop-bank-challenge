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
        private bool _locked = false;

        // Cannot deposit or withdraw money from SavingsAccount, only transfer to or from other accounts in the bank
        public SavingsAccount(Guid ownerID, string accountName) : base(ownerID, accountName)
        {
            
        }

        public void LockAccount()
        {
            _locked = true;
        }

        public void UnlockAccount()
        {
            _locked = false;
        }

        public bool Locked { get { return _locked; } }
    }
}

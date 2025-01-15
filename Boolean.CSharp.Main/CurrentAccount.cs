using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        private float _overdraftAmount;

        public CurrentAccount()
        {
            _OverdraftAmount = 0f;
        }

        public void Deposit(float amount)
        {

        }

        public void Withdraw(float amount)
        {

        }

        public void RequestOverdraft(float amount)
        {

        }

        public void ManageOverdraftRequest(bool approve)
        {

        }

        public float OverdraftAmount { get { return _overdraftAmount; } }
    }
}

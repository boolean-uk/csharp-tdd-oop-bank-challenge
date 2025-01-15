using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Overdraft
    {
        private bool  _isOverdraftAllowed = false;
        private float _overdraftMax = 0.0f;
        private float _currentDebt = 0.0f;
        
        public bool IsOverdraftAllowed { get => _isOverdraftAllowed; }
        public float overdraftAmount { get => _overdraftMax; }
        public Overdraft(IOverdraftOwner configurer, Account self)
        {
            configurer.setConfigFunc(this, configOverdraft, self);
        }

        public float? loanFromOverdraft(float requestedAmount)
        {
            if (_currentDebt + requestedAmount > _overdraftMax)
            {
                Console.WriteLine($"Current debt ({_currentDebt}) + requested amount ({requestedAmount}) is more than max overdraft ({_overdraftMax})");
                return null;
            }

            _currentDebt = _currentDebt + requestedAmount;
            return requestedAmount;
        }

        private void disableOverdraft()
        {
            _isOverdraftAllowed = false;
            _overdraftMax = 0.0f;
        }
        private void configOverdraft(float amount)
        {
            
            if (amount <= 0)
            {
                disableOverdraft();
                return;
            }

            _isOverdraftAllowed = true;
            _overdraftMax = amount;
        }

    }
}

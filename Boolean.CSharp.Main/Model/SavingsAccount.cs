using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class SavingsAccount
    {
        private float _balance { get; set; }
        private int _interestRate { get; set; }

        internal SavingsAccount(int interestRate)
        {
            this._balance = 0f;
            this._interestRate = 0;
        }
        public float getBalance() { return this._balance; }
        public void deposit(float amount) { _balance += amount; }
        public float withdraw(float amount) { _balance -= amount; return amount;  }
    }
}

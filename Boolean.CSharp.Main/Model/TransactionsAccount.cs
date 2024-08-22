using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class TransactionsAccount
    {
        private float _balance {  get; set; }

        public TransactionsAccount() { 
        this._balance = 0f;
        }

        public void deposit(float amount) { _balance += amount; }
        public float withdraw(float amount) { _balance -= amount; return amount; }
    }
}

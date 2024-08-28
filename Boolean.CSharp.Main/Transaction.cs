using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction(float amount, float balance)
    {
        private string _date = DateTime.Now.ToString("dd/MM/yyyy");
        private float _amount = amount;
        private float _balance = balance;

        public float Amount { get { return _amount; } }
    }
}

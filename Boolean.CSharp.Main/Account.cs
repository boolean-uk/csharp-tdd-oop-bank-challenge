using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _number;
        private int _customerId;
        List<Transaction> _transactions = new List<Transaction>();

        public Account(int customerId)
        {
            _number = GenerateAccountNumber();
            _customerId = customerId;
        }

        private string GenerateAccountNumber()
        {
            return "";
            
        }

        public string Number { get => _number; }
    }
}

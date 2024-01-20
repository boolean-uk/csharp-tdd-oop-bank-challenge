using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public AccountType Type { get; }

        public float getBalance();

        public bool MakeTransaction( float amount, TransactionType type, string date);

        public void ListBankStatement();

    }
}

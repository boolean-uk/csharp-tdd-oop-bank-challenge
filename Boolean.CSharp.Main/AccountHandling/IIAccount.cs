using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public AccountType ACCTYPE { get; }

        public string BRANCH { get; }

        public string ID { get; }

        public List<Transaction> TRANSACTIONS { get; }
        public float getBalance();

        public bool Withdraw(float amount, string date);

        public bool Withdraw(float amount);

        public bool Deposit(float amount, string date);

        public bool Deposit(float amount);

        public List<string> ListBankStatement();

    }
}

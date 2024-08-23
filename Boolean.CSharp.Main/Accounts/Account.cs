using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        protected User _owner;
        protected List<Transaction> _transactions = new List<Transaction>();

        public int? GetBalance(User user)
        {
            return null;
        }

        public bool Deposit(int amount, User user)
        {
            return false;
        }

        public bool Withdraw(int amount, User user)
        {
            return false;
        }

        public string GetBankStatement(User user)
        {
            return string.Empty;
        }

        public Branch? GetBranch(User user)
        {
            return null;
        }

        public bool SetOverdraft(int amount, User user)
        {
            return false;
        }

        public User? GetOwner(User user)
        {

            return null;
        }
    }
}
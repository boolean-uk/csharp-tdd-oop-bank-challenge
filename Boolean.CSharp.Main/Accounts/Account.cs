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

        protected Account(User owner)
        {
            _owner = owner;
        }

        public int? GetBalance(User userAttemptingAction)
        {
            return null;
        }

        public bool Deposit(int amount, User userAttemptingAction)
        {
            return false;
        }

        public bool Withdraw(int amount, User userAttemptingAction)
        {
            return false;
        }

        public string GetBankStatement(User userAttemptingAction)
        {
            return string.Empty;
        }

        public Branch? GetBranch(User userAttemptingAction)
        {
            return null;
        }

        public bool SetOverdraft(int amount, User userAttemptingAction)
        {
            return false;
        }

        public User? GetOwner(User userAttemptingAction)
        {
            return null;
        }
    }
}
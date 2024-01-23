using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.MessageProvider;
using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : IAccount
    {
        IBankTransaction _transactions;
        List<IUser> authorizedUsers;
        private decimal _balance = 0m;

        public SavingsAccount(Customer user)
        {
            _transactions = new TransactionManager();
            authorizedUsers = new List<IUser> { user };
            user.RegisterAccount(this);
        }

        public bool AddAccountToBankBranch(IBankBranch branch)
        {
            return branch.AddAccountToBranch(this);
        }

        public bool AddUserToAccount(IUser user)
        {
            int val1 = authorizedUsers.Count;
            authorizedUsers.Add(user);
            int val2 = authorizedUsers.Count;
            return val2 > val1;
        }

        public bool Deposit(decimal amount)
        {
            _transactions.AddDepositTransaction(amount);
            decimal oldBalance = _balance;
            _balance += amount;
            if (_balance == (oldBalance + amount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public IBankBranch GetBankBranch()
        {
            throw new NotImplementedException();
        }

        public void PrintBankStatement(DateTime start, DateTime end, bool sendSMS = false)
        {
            string statement = _transactions.PrintTransactions(start, end);
            if (sendSMS)
            {
                SendStatementToCustomer(statement);
            }
        }

        /// <summary>
        /// Attempt to set overdraft limit on a savingsaccount object. Which is not allowed
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public decimal SetOverdrawLimit(decimal limit, IUser user)
        {
            return 0m;
        }

        public decimal Withdraw(decimal amount)
        {
            if (_balance > amount)
            {
                _transactions.AddWithdrawTransaction(amount);
                _balance -= amount;
                return amount;
            }
            else
            {
                return 0m;
            }
        }

        private void SendStatementToCustomer(string msg)
        {
            ITextSender provider = new TwilioSMSSender();
            provider.SendMessage(msg);
        }
    }
}

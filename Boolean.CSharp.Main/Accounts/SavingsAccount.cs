using Boolean.CSharp.Main.Branch;
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
            throw new NotImplementedException();
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

        public void PrintBankStatement(DateTime start, DateTime end)
        {
            _transactions.PrintTransactions(start, end);
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
    }
}

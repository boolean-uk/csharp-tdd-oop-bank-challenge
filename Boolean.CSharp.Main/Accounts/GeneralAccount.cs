using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class GeneralAccount : IAccount
    {
        IBankTransaction _transactions;
        List<IUser> authorizedUsers = new List<IUser>();
        private decimal _balance = 0m;
        private decimal _overdrawLimit = 0m;

        public GeneralAccount()
        {
            _transactions = new TransactionManager();
        }

        public decimal setOverdrawLimit(decimal limit, IUser user) 
        {
            if (user is Manager) 
            {
                _overdrawLimit = limit;
            }
            return _overdrawLimit;
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
            decimal balance = _transactions.CalculateAccountBalance();
            _balance = balance;
            return balance;
        }

        public void PrintBankStatement(DateTime start, DateTime end)
        {
            _transactions.PrintTransactions(start, end);
        }

        /// <summary>
        /// Withdraw an amount from the account. Fails if the amount withdrawn reduces the balance below the overdraw limit
        /// </summary>
        /// <param name="amount"> The amount of money to withdraw from the account </param>
        /// <returns> The amount withdrawn. If 0m is returned the withdraw failed. </returns>
        public decimal Withdraw(decimal amount)
        {
            if ((_balance - amount) > _overdrawLimit)
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

using Boolean.CSharp.Main.Classes.Accounts;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes.User
{
    public class CustomerUser : IUser
    {
        List<ABankAccount> _accounts;

        public CustomerUser()
        {
            _accounts = new List<ABankAccount>();
        }

        public string CreateAccount(ABankAccount account)
        {
            if (account != null)
            {
                _accounts.Add(account);
                return "New Account has been made";
            }
            return "Error, something went wrong and we cant make your account";
        }

        public double Deposit(double money, int account)
        {
            if (_accounts.Count >= account)
            {
                return _accounts[account].Transaction(new BankStatement(money, true, eType.Credit, DateTime.Now));
            }
            return -1d;
        }

        public bool Withdraw(double withdrawl, int account)
        {
            if (_accounts.Count >= account)
            {
                if (_accounts[account].Money()-withdrawl >= -1*_accounts[account].OverdraftAmount())
                {
                    _accounts[account].Transaction(new BankStatement(withdrawl, true, eType.Debit, DateTime.Now));
                    return true;
                }
            }
            return false;
        }

        public string GenerateStatement(int account)
        {
            return _accounts[account].WriteTransactions().ToString();
        }

        public string CheckBranch(int account)
        {
            return _accounts[account].Branch.ToString();
        }

        public OverdraftRequest RequestOverdraft(double money, int account)
        {
            OverdraftRequest test = new OverdraftRequest 
            {
                Amount = money,
                RequestStatus = eStatus.Pending,
                RequestTime = DateTime.Now
            };
            _accounts[account].Overdraft(test);
            return test;
        }
    }
}

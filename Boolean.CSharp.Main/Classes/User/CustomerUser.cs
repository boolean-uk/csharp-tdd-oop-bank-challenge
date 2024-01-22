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
                if (withdrawl <= _accounts[account].Money())
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

        public BankStatement RequestOverdraft(double money, int account)
        {
            double draft = _accounts[account].Money() - money;
            if (draft < 0)
            {
                BankStatement test = new BankStatement(draft, false, eType.OverDraft, DateTime.Now);
                return test;
            }
            return null;
        }
    }
}

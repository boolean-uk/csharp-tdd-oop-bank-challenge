using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class Bank(string bankSecret = "")
    {
        private string _bankSecret = bankSecret;
        private Dictionary<Guid, Account> _accounts = [];
        private Dictionary<Guid, List<AccountTransaction>> _overdraftTransactions = [];
        private Dictionary<int, Tuple<Guid, double>> _overdraftRequests = [];
        private Dictionary<int, Tuple<Guid, double>> _rejectedOverdraftRequests = [];
        private int _runningOverdraftId = 0;
        public Guid CreateAccount(string name, Branch branch)
        {
            Account newAccount = new RegularAccount(name, branch, _bankSecret);
            _accounts.Add(newAccount.AccountId, newAccount);
            return newAccount.AccountId;
        }
        public Guid CreateAccount(string name, double withdrawalLimit, DateTime withdrawalLock, Branch branch)
        {
            Account newAccount = new SavingsAccount(name, withdrawalLimit, withdrawalLock, branch, _bankSecret);
            _accounts.Add(newAccount.AccountId, newAccount);
            return newAccount.AccountId;
        }

        public Account GetAccount(Guid accountId)
        {
            if (!_accounts.TryGetValue(accountId, out Account? value)) throw new ArgumentException("That account does not exsist!");
            return value;
        }
        public int RequestOverdraft(Guid accountId, double amount)
        {
            if (!_accounts.TryGetValue(accountId, out Account? account)) throw new ArgumentException("That account does not exsist!");
            if (account.Balance > amount) throw new ArgumentException("You have that amount available, you do not need an overdraft!");
            _overdraftRequests.Add(_runningOverdraftId, new(accountId, amount));
            return _runningOverdraftId++;
        }

        public void HandleOverdraftRequest(int overdraftId, bool accept)
        {
            if (!_overdraftRequests.TryGetValue(overdraftId, out Tuple<Guid, double>? request)) throw new ArgumentException("That request does not exsist!");
            if (accept)
            {
                Account account = _accounts[request.Item1];
                if (!_overdraftTransactions.ContainsKey(account.AccountId)) _overdraftTransactions[account.AccountId] = [];
                AccountTransaction transaction = new AccountTransaction(request.Item1, -request.Item2);
                _overdraftTransactions[request.Item1].Add(transaction);
                account.AddTransaction(transaction, _bankSecret);
            } else
            {
                _rejectedOverdraftRequests.Add(overdraftId, request);
            }
            _overdraftRequests.Remove(overdraftId);
        }

        public List<Tuple<int, Guid, double>> GetOverdraftRequests(Guid accountId)
        {
            return _overdraftRequests.Where(x => x.Value.Item1 == accountId).Select(x => new Tuple<int, Guid, double>(x.Key, x.Value.Item1, x.Value.Item2)).ToList();
        }

        public Tuple<Guid, double> GetOverdraftRequests(int overdraftId)
        {
            if (!_overdraftRequests.TryGetValue(overdraftId, out Tuple<Guid, double>? value)) throw new ArgumentException($"{overdraftId} does not exist");
            return value;
        }

        public Tuple<int, string> GetOverdraftStatus(int overdraftId)
        {
            if (_overdraftRequests.ContainsKey(overdraftId)) return new Tuple<int, string>(1, "Pending!");
            if (_rejectedOverdraftRequests.ContainsKey(overdraftId)) return new Tuple<int, string>(0, "Rejected!");
            return new Tuple<int, string>(2, "Accepted!");
        }

    }
}

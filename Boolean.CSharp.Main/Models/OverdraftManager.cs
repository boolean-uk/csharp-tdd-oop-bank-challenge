using Boolean.CSharp.Main.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class OverdraftRequest
    {
        public int AccountNumber { get; set; }
        public double Amount { get; set; }

        public OverdraftRequest(int accountNumber, double amount)
        {
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }

    public class OverdraftManager
    {
        public List<OverdraftRequest> Requests { get; set; }
        private AccountManager _accountManager { get; set; }

        public OverdraftManager(AccountManager accountManager)
        {
            Requests = new List<OverdraftRequest>();
            _accountManager = accountManager;
        }

        public void CreateRequest(int accountNumber, double amount)
        {
            Requests.Add(new OverdraftRequest(accountNumber, amount));
        }

        public void ApproveRequest(int accountNumber, double amount)
        {
            OverdraftRequest request = Requests.FirstOrDefault(r => r.AccountNumber == accountNumber);
            if (request == null)
                throw new Exception("Account number not found in requests");

            Accounts.Account account = _accountManager.Accounts.FirstOrDefault(a => a.Key == accountNumber).Value;
            if (account == null)
                throw new Exception("Account number not found in accounts");

            if (account is CurrentAccount currentAccount)
            {
                currentAccount.OverdraftLimit = amount;
                Requests.Remove(request);
            }
            else
            {
                throw new InvalidOperationException("Only current accounts can have overdrafts.");
            }
        }

        public void RejectRequest(int accountNumber)
        {
            OverdraftRequest request = Requests.FirstOrDefault(r => r.AccountNumber == accountNumber);
            if (request == null)
                throw new Exception("Account number not found in requests");

            Requests.Remove(request);
        }
    }
}

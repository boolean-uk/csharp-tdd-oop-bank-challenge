using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class BankManager : IBankManager
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public BankManager(string name)
        {
            Name = name;
        }
        public string ManageOverdraftRequest(Account account, bool approved)
        {
            string message = "Managing overdrafts...";

            ITransaction? latestOverdraftRequest = account.OverdraftRequests
                .OrderByDescending(t => t.Date)
                .Where(t => t.Type == TransactionType.Debit && t.Status == TransactionStatus.Pending)
                .FirstOrDefault();

            if (latestOverdraftRequest == null)
            {
                message = "No overdraft requests found";
            }

            int index = account.OverdraftRequests.IndexOf(latestOverdraftRequest);

            if (index >= 0)
            {
                account.OverdraftRequests[index].Status = approved ? TransactionStatus.Approved : TransactionStatus.Refused;
                if(approved)
                {
                    account.Withdraw(latestOverdraftRequest.Amount);
                }
                message = approved ? "The overdraft was approved." : "The overdraft was rejected.";
            }

            return message;
        }
    }
}
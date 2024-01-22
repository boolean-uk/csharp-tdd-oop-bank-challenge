using Boolean.CSharp.Main.Accounts;
using Microsoft.Extensions.Configuration;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Models
{
    public class Customer
    {
        private readonly List<IAccount> _accounts = [];
        public void CreateAccount(IAccount account)
        {
            _accounts.Add(account);
        }

        public List<IAccount> GetAccounts()
        {
            return _accounts;
        }

        public int GetNumberOfAccounts()
        {
            return _accounts.Count;
        }

        public static void RequestOverdraft(Request request)
        {
            request.Account.Branch.Requests.Add(request);
        }
    }
}

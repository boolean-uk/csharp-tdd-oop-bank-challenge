using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.PersonType
{
    public class Manager
    {
        
        private Dictionary<string, List<IAccount>> accountLocations = new Dictionary<string, List<IAccount>>();
        public bool RespondToOverdraft(string response)
        {
            string finalResponse = response.ToLower();
            if (finalResponse == "approve")
            {
                return true;
            }
            return false;
        }

        public void AddAccount(IAccount account)
        {
            // match accounts with different locations
            if (accountLocations.ContainsKey(account.location))
            {
                accountLocations[account.location].Add(account);
            }
            else
            {
                List<IAccount> list = new List<IAccount>();
                list.Add(account);
                accountLocations.Add(account.location, list);

            }
        }

        public List<IAccount> GetAccounts(string location)
        {
            return accountLocations[location];
        }
    }
}

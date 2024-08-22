using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {

        private List<Account> _accounts = new List<Account>();

        private List<string> _users { get { return _accounts.Select(account => account.Owner).Distinct().ToList(); } }
        public bool AddAccount(string user, string bankType)
        {

            if (bankType == "current")
            {
               _accounts.Add(new CurrentAccount(_accounts.Count(), bankType, user));
                return true;
            }
            if (bankType == "savings")
            {
                _accounts.Add(new SavingsAccount(_accounts.Count(), bankType, user));
                return true;
            }
            
            return false;
        }

        public string PrintBankStateMent(string user)
        {
            List<Account> accountsWithUser = _accounts.Where(account => account.Owner == user).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("date     || credit   || depit    || balance  ");

            foreach (Account account in accountsWithUser)
            {
                sb.AppendLine(account.GenerateStatement());
            }

            return sb.ToString();
        }
    }
}

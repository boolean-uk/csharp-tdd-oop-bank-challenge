using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Manager
    {

        private List<Account> accounts;
        public Manager(List<Account> allAccounts)
        {
            accounts = allAccounts;
        }


        public void CheckOverdrafts()
        {
            string input = "n";
            foreach (var account in accounts)
            {
                if (account.GetOverdraftStatus() == Enums.OverdraftStatus.Pending)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Would you like to approve or reject the overdraft?");
                    Console.WriteLine("Account Transactions: ");
                    account.ShowTransactions();
                    input = Console.ReadLine().ToLower();

                    if (input.Equals("y"))
                    {
                        account.SetOverdraftStatus(Enums.OverdraftStatus.Approved);
                    }
                    else if (input.Equals("n"))
                    {
                        account.SetOverdraftStatus(Enums.OverdraftStatus.Rejected);
                    }
                    else { break; }
                }
            }
        }


        public void AutomaticOverdraft(string decision)
        {
            foreach (var account in accounts)
            {
                if (decision.Equals("yes"))
                {
                    account.SetOverdraftStatus(Enums.OverdraftStatus.Approved);
                }
                else if (decision.Equals("no"))
                {
                    account.SetOverdraftStatus(Enums.OverdraftStatus.Rejected);
                }
                else { break; }
            }
        }
    }
}

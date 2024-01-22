using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{


public class UserAccount
{
    public string Name { get; set; }
    public string AccountType { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public string BranchName { get; set; }

    private static Dictionary<string, UserAccount> accountsDictionary = new Dictionary<string, UserAccount>();
    public static UserAccount CreateAccount(string name, string accountType, string accountBranch)
        {
            UserAccount newAccount = new UserAccount
            {
                Name = name,
                AccountType = accountType,
                BranchName = accountBranch
            };
            accountsDictionary.Add(accountBranch, newAccount);
            return newAccount;
        }

    public static UserAccount GetAccount(string accountName, string accountType, string accountBranch)
    {
        foreach (var account in accountsDictionary.Values)
        {
            if (account.Name == accountName && account.AccountType == accountType && account.BranchName == accountBranch)
            {
                return account;
            }
        }
        return null;
    }
    }
}
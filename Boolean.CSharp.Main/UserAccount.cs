using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
public class UserAccount
{
    public string Name { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastUpdateDate { get; set; }

    private static int accountNum = 1;
   
    private static Dictionary<string, UserAccount> accountsDictionary = new Dictionary<string, UserAccount>();
    public static UserAccount CreateAccount(string name, string accountType)
        {
            string accountNumber = GenerateAccountNumber();
            UserAccount newAccount = new UserAccount
            {
                Name = name,
                AccountNumber = accountNumber,
                AccountType = accountType
            };
            accountsDictionary.Add(accountNumber, newAccount);
            return newAccount;
        }

    private static string GenerateAccountNumber()
    {
        return $"ACCT-{accountNum++}";
    }
    public static UserAccount GetAccount(string accountName, string accountType)
    {
        foreach (var account in accountsDictionary.Values)
        {
            if (account.Name == accountName && account.AccountType == accountType)
            {
                return account;
            }
        }
        return null;
    }
    }
}
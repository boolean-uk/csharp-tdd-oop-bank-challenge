using System.Linq.Expressions;
using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models;

public class Customer(string name, int socialSecurityNumber, string phoneNumber, DateTime birthDate) : IPerson
{
    private string _name = name;
    private string _phoneNumber = phoneNumber;
    private DateTime _birthDate = birthDate;
    
    public int SocialSecurityNumber { get; } = socialSecurityNumber;
    public List<Account> Accounts { get; } = new();

    public Account CreateAccount(string name, AccountType accountType)
    {
        Account? newAccount = null;
        if (Accounts.Any(a => a.Name.Equals(name))) return newAccount;
        switch (accountType)
        {
            case AccountType.Spending:
                newAccount = new SpendingAccount(name);
                break;
            case AccountType.Saving:
                newAccount = new SavingAccount(name);
                break;
            case AccountType.Credit:
                newAccount = new CreditAccount(name);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(accountType), accountType, null);
        }
        Accounts.Add(newAccount);
        return newAccount;
    }

    public Account GetAccount(string accountName)
    {
        var account = Accounts.FirstOrDefault(a => a.Name.ToLower().Equals(accountName.ToLower()))!;
        return account;
    }

    public bool RequestOverDraft(Account account, decimal amount)
    {
        return Overdraft.NewOverdraftRequest(this, account, amount);
    }
}
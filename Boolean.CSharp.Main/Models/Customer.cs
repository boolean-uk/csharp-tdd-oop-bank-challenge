using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Models;

public class Customer(string name, int socialSecurityNumber, string phoneNumber, DateTime birthDate)
{
    private string _name = name;
    private string _phoneNumber = phoneNumber;
    private DateTime _birthDate = birthDate;
    private bool _smsNotification = false;
    
    public int SocialSecurityNumber { get; } = socialSecurityNumber;
    public List<IAccount> Accounts { get; } = new List<IAccount>();

    public bool CreateAccount(string name, AccountType accountType)
    {
        return false;
    }

    public IAccount GetAccount(string accountName)
    {
        return null;
    }

    public bool RequestOverDraft(IAccount account, decimal amount)
    {
        return false;
    }
    
    public void SetSmsNotification(bool value) => _smsNotification = value;
}
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Models;

public class Customer(string name, int socialSecurityNumber, string phoneNumber, DateTime birthDate)
{
    private string _name = name;
    private int _socialSecurityNumber = socialSecurityNumber;
    private string _phoneNumber = phoneNumber;
    private DateTime _birthDate = birthDate;
    private List<IAccount> _accounts = new List<IAccount>();
    private bool _smsNotification = false;

    public bool CreateAccount(IAccount account)
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
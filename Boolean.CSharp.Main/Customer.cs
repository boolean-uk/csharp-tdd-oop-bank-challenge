using System;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main;

public class Customer : User
{
    private List<Account> _accountList;

    public readonly string phoneNumber;

    public Customer(string name, string phoneNumber) : base(name, Role.Customer)
    {
        _accountList = new List<Account>();
        this.phoneNumber = phoneNumber;
    }

    public void CreateAccount(Account account)
    {
        _accountList.Add(account);
    }

    public void DeleteAccount(Account account)
    {
        _accountList.Remove(account);
    }


    public string getStatement(Guid accountId)
    {
        return "Statement";
    }
}

namespace Boolean.CSharp.Main.Models.Accounts;

public class SavingAccount(Customer customer, string name) : Account(customer, name, AccountType.Saving)
{
}
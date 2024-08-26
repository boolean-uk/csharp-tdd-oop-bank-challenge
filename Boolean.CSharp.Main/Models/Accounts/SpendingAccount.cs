namespace Boolean.CSharp.Main.Models.Accounts;

public class SpendingAccount(Customer customer, string name) : Account(customer, name, AccountType.Spending)
{
}
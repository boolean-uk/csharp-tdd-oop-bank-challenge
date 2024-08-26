namespace Boolean.CSharp.Main.Models.Accounts;

public class CreditAccount(Customer customer, string name) : Account(customer, name, AccountType.Credit)
{
}
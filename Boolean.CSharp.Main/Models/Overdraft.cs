using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models;

public static class Overdraft
{
    public static List<OverdraftRequests> OverdraftRequests = new();

    public static bool ApproveOverdraft(IPerson person, OverdraftRequests request)
    {
        if (person is not Manager) return false;
        request.Account.BankTransactions.Add(request.BT);
        OverdraftRequests.Remove(request);
        return true;
    }

    public static bool NewOverdraftRequest(Customer customer, Account account, BankTransaction bt, decimal overDraftamount)
    {
        if (OverdraftRequests.Any(r => r.Account.Equals(account))) return false;
        OverdraftRequests.Add(new OverdraftRequests(customer, account, bt, overDraftamount));
        return true;
    }
}

public class OverdraftRequests(Customer customer, Account account, BankTransaction bt, decimal overdraftAmount)
{
    public Customer Customer { get; } = customer;
    public Account Account { get; } = account;
    public BankTransaction BT { get; } = bt;
    public decimal OverdraftAmount { get; } = overdraftAmount;
}
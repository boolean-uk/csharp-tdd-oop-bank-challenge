using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models;

public static class Overdraft
{
    public static List<OverdraftRequests> OverdraftRequests = new();
    public static Dictionary<Account, decimal> ApprovedOverdrafts = new();

    public static bool ApproveOverdraft(IPerson person, OverdraftRequests request)
    {
        if (person is not Manager) return false;
        ApprovedOverdrafts.Add(request.Account, request.OverdraftAmount);
        OverdraftRequests.Remove(request);
        return true;
    }

    public static bool NewOverdraftRequest(Customer customer, Account account, decimal overDraftamount)
    {
        var overdraft = 0m;
        if (overDraftamount > 0) overdraft *= -1; 
        OverdraftRequests.Add(new OverdraftRequests(customer, account, overdraft));
        return true;
    }
}

public class OverdraftRequests(Customer customer, Account account, decimal overdraftAmount)
{
    public Customer Customer { get; } = customer;
    public Account Account { get; } = account;
    public decimal OverdraftAmount { get; } = overdraftAmount;
}
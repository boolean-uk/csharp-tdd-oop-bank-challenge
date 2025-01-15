namespace Boolean.CSharp.Main;

public class OverdraftRequest
{
    private decimal _wantedLimit = 0;
    private IOverdraftable _account;
    
    public OverdraftRequest(decimal limit)
    {
        _wantedLimit = limit;
    }
    
    public void Verdict(bool approved, out decimal overdraftLimit)
    {
        if (approved)
        {
            overdraftLimit = _wantedLimit;
        }
        else
        {
            // Denied credit should reset the overdraft limit to protect the bank
            overdraftLimit = 0;
        }
    }
}
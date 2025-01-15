// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;



// Only "CurrentAccounts" are allowed to withdraw
public class CurrentAccount : Account, IOverdraftable
{
    private Overdraft _overdraftInstance;
    public Overdraft overdraftConf => _overdraftInstance;

    public override void Initialize(Bank bank, Account self)
    {
        // Implement initialization needs for current accounts... if any
        _overdraftInstance = new Overdraft(bank, self);
        
    }

    protected override float? handleWithdrawFail(float sumToWithdraw)
    {
        Console.WriteLine($"Balance is too low, try overdraw");
        return  _overdraftInstance.loanFromOverdraft(sumToWithdraw);
        
    }
}

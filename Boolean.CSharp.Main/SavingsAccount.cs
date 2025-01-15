// See https://aka.ms/new-console-template for more information
public class SavingsAccount : Account
{
    public override void Initialize(Bank bank, Account self)
    {
        // Implement initialization needs for saving accounts... if any
    }

    protected override float? handleWithdrawFail(float sumToWithdraw)
    {
        return null;
    }
}

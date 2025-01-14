namespace Boolean.CSharp.Main;

public class CheckingAccount : Account, IOverdraftable
{
    public CheckingAccount(ref User accountHolder) : base(ref accountHolder)
    {
    }
}
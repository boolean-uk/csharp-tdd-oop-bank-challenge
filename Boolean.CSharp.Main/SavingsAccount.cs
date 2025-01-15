namespace Boolean.CSharp.Main;

public class SavingsAccount : Account
{
    public SavingsAccount(ref User accountHolder) : base(ref accountHolder)
    {
        _branch = Branch.Kristiansand;
    }
    
    public SavingsAccount(ref User accountHolder, Branch branch) : base(ref accountHolder, branch)
    {
    }
}
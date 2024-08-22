using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main;

public class Bank(string name)
{
    private string _name = name;
    private List<IBranch> _branches = new();

    public bool AddBranch(IBranch branch)
    {
        return false;
    }

    public List<IBranch> GetBranches()
    {
        throw new NotImplementedException();
    }
}
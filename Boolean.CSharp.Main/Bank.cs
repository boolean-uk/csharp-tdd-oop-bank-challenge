using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main;

public class Bank(string name)
{
    private string _name = name;
    private List<IBranch> _branches = new();

    public void AddBranch(IBranch branch) => _branches.Add(branch);

    public List<IBranch> GetBranches() => _branches;
}
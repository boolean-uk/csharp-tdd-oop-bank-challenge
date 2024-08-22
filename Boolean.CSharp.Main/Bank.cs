using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Core;

public class Bank(string name)
{
    private string _name = name;
    private List<IBranch> _branches = new();
}
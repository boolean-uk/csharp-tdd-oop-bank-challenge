namespace Boolean.CSharp.Main;

public class Bank
{
    private string _name;
    private string _regNr;
    private List<BankBranch> _banks;
    private Manager _manager;
    public Bank(string name, string regNr, Manager manager)
    {
        _name = name;
        _regNr = regNr;
        _banks = new List<BankBranch>();
        _manager = manager;
    }

    public string Name { get { return _name; } }
    public List<BankBranch> getBanks()
    {
        return _banks;
    }

    public BankBranch? GetBankBranch(string name)
    {
        return _banks.Find(x => x.Name == name);
    }

    public bool createBankBranch(string branchName)
    {
        BankBranch? exists = _banks.Find(x => x.Name == branchName.Trim());
        if (branchName.Trim() == string.Empty || exists != null)
        {
            return false;
        }
        _banks.Add(new BankBranch(branchName.Trim(), _regNr, _manager));
        return true;
    }
}

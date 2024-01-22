namespace Boolean.CSharp.Main;

public class Core
{
    List<BankAccount> _accounts;
    public Core()
    {
        _accounts = new List<BankAccount>();
    }

    public bool createCurrentAccount(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public bool createSavingsAccount(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public BankAccount? getAccountByNumber(string accountNumber)
    {
        return _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
    }
}

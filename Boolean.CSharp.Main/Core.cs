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
        if (accountNumber.Trim().Length == 11)
        {
            if (!_accounts.Exists(x => x.AccountNumber == accountNumber))
            {
                _accounts.Add(new CurrentAccount(accountNumber));
                Console.WriteLine("CurrentAccount created");
                return true;
            }
            Console.WriteLine("Account number already exists");
            return false;
        }
        Console.WriteLine("Account number is invalid (length has to be 11)");
        return false;
    }

    public bool createSavingsAccount(string accountNumber)
    {
        if (accountNumber.Trim().Length == 11)
        {
            if (!_accounts.Exists(x => x.AccountNumber == accountNumber))
            {
                _accounts.Add(new SavingsAccount(accountNumber));
                Console.WriteLine("SavingsAccount created");
                return true;
            }
            Console.WriteLine("Account number already exists");
            return false;
        }
        Console.WriteLine("Account number is invalid (length has to be 11)");
        return false;
    }

    public BankAccount? getAccountByNumber(string accountNumber)
    {
        return _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
    }
}

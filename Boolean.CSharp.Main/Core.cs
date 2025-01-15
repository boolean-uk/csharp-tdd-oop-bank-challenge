namespace Boolean.CSharp.Main;

public class AdminUser : User
{
    public bool ChangeAllowedOverdraft(User user, string accountName, decimal overdraftAmount)
    {
        return user.AccessAccount(accountName, this)?.ChangeOverdraft(overdraftAmount) ?? false;
    }
}

public class User
{
    public required string UserId { get; init; }
    private List<Account> Accounts = new List<Account>();

    public bool CreateAccount(string accountName, AccountType accountType, BankBranch bankBranch)
    {
        if (Accounts.Any(acc => acc.Name == accountName))
        {
            return false;
        }
        Accounts.Add(
            new Account
            {
                Type = accountType,
                Branch = bankBranch,
                Name = accountName,
            }
        );
        return true;
    }

    private Account? GetAccount(string accountName)
    {
        return Accounts.Find(acc => acc.Name == accountName);
    }

    public Account? AccessAccount(string accountName, User accessor)
    {
        if (!(accessor is AdminUser))
        {
            return null;
        }
        return Accounts.Find(acc => acc.Name == accountName);
    }

    public void Deposit(string accountName, decimal amount)
    {
        this.GetAccount(accountName)?.Deposit(amount);
    }

    public bool Withdraw(string accountName, decimal amount)
    {
        return this.GetAccount(accountName)?.Withdraw(amount) ?? false;
    }

    public decimal? GetBalance(string accountName)
    {
        return this.GetAccount(accountName)?.Balance;
    }

    public decimal? GetAllowedOverdraft(string accountName)
    {
        return this.GetAccount(accountName)?.AllowedOverdraft;
    }

    public void SendOverdraftRequest(string message)
    {
        throw new NotImplementedException(
            "Please call your local manager to request overdraft permission"
        );
    }
}

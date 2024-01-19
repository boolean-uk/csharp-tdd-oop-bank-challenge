namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        AccountTypes GetAccountType();
        double GetBalance();
        Customer GetAccountOwner();
        bool Deposit(double amount);
        bool Withdraw(double amount);
    }
}

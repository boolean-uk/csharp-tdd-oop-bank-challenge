namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        void Deposit(double amount, DateTime date);
        void Withdraw(double amount, DateTime date);
        string PrintStatement();
    }
}

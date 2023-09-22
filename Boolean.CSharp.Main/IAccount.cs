namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        AllEnums.Branches Branch { get; }
        void Deposit(double amount, DateTime date);
        void Withdraw(double amount, DateTime date);
        string PrintStatement();
        double GetBalance();
    }
}

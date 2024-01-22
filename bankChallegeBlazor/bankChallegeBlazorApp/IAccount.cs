namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        AllEnums.Branches Branch { get; }
        void Deposit(double amount, DateTime date);
        void Withdraw(double amount, DateTime date);
        string PrintStatement();
        double GetBalance();
        double OverdraftLimit { get; }
        AllEnums.OverdraftStatus OverdraftStatus { get; }
        void RequestOverdraft(double amount);
        void ApproveOverdraft();
        void RejectOverdraft();
    }
}

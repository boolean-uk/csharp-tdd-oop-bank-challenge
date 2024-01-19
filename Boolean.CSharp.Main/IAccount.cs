namespace Boolean.CSharp.Main;

public interface IAccount
{
    string AccountNumber { get; }
    bool deposit(double amount);
    bool withdraw(double amount);
    double checkBalance();
    string generateBankStatement();
}

namespace Boolean.CSharp.Main;

public class BankAccount
{
    private string _accountNumber;
    private double _balance;
    private List<Tuple<DateOnly, double>> _transactions;

    public BankAccount(string accountNumber)
    {
        _accountNumber = accountNumber;
        _balance = 0;
        _transactions = new List<Tuple<DateOnly, double>>();
    }

    public string AccountNumber { get { return _accountNumber; } }
    public double checkBalance()
    {
        return _balance;
    }
    public bool deposit(double amount)
    {
        throw new NotImplementedException();
    }
    public bool withdraw(double amount)
    {
        throw new NotImplementedException();
    }
    public string generateBankStatement()
    {
        throw new NotImplementedException();
    }
}

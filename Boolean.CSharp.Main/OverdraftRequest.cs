namespace Boolean.CSharp.Main;

public class OverdraftRequest
{
    private int _id;
    private BankAccount _bankAccount;
    private double _amount;
    private DateTime _timeRequested;
    private string _status;
    public OverdraftRequest(int id, BankAccount bankAccount, double amount)
    {
        _id = id;
        _bankAccount = bankAccount;
        _amount = amount;
        _timeRequested = DateTime.Now;
        _status = "Pending";
    }

    public int Id { get { return _id; } }
    public BankAccount BankAccount { get { return _bankAccount; } }
    public double Amount { get { return _amount; } }
    public DateTime TimeRequested { get { return _timeRequested; } }

    public void grantRequest()
    {
        if (_status == "Pending")
        {
            _bankAccount.setOverdraftAmount(_amount);
            _status = "Granted";
        }
    }

    public void denyRequest()
    {
        if ( _status == "Pending")
        {
            _status = "Denied";
        }
    }
}

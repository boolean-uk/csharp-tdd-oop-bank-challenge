// See https://aka.ms/new-console-template for more information
public class Record
{
    private DateTime _transactionDate;
    private int _senderAccountId;
    private int _recieverAccountId;
    private float _amount;
    private float _balanceAtTransaction;
    public float Amount { get => _amount; }
    public DateTime TransactionDate { get => _transactionDate; }
    public Record(Account account, float amount, int senderAccountId, int recieverAccountId )
    {
        _transactionDate = DateTime.Now;
        _senderAccountId = senderAccountId;
        _recieverAccountId = recieverAccountId;
        _amount  = amount;
        _balanceAtTransaction = account.GetBalance; // TODO FIX

    }
}
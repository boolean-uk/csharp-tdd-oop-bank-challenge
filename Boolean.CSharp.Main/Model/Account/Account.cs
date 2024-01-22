
using System.Text;

namespace Boolean.CSharp.Main;

public abstract class Account : IAccount
{
    private List<Transaction> _transactions;
    private Branch _branch;
    private Signature _signature;
    private Guid _id;

    public List<Transaction> Transactions => _transactions;
    public Branch Branch => _branch;
    public Signature Signature => _signature;
    public Guid Id => _id;

    public Account(Branch branch)
    {
        this._branch = branch;
        this._transactions = new List<Transaction>();
        this._signature = new Signature();
        this._id = Guid.NewGuid();
    }

    public Transaction Deposit(int amount)
    {
        Transaction transaction = new Transaction(_id, amount, GetBalance()+amount, TransactionType.CREDIT, _signature);
        _transactions.Add(transaction);
        return transaction;
    }

    public Transaction Deposit(Transaction transaction)
    {
        Transaction t = new Transaction(_id, transaction.Amount, GetBalance()+transaction.Amount, TransactionType.CREDIT, transaction.Signature);
        _transactions.Add(t);
        return t;
    }

    public int GetBalance()
    {
        if(_transactions.Count == 0)
            return 0;
        return _transactions.Last().Balance;
    }

    public StringBuilder PrintReceipt()
    {
        StringBuilder sb = new StringBuilder();
        var sortedListDescending = _transactions.OrderByDescending(obj => obj.Date).ToList();
        sb.AppendLine($"Date      || {FormatField("Credit")} || {FormatField("Debit")} || {FormatField("Balance")} || {FormatField("Signature")}");
        foreach (Transaction t in sortedListDescending)
        {
            if(t.Type == TransactionType.CREDIT) {
                sb.AppendLine($"{t.Date.Day + "/" + t.Date.Month + "/" + t.Date.Year} || {FormatField(t.Amount.ToString())} || {FormatField("")} || {FormatField(t.Balance.ToString())} || {FormatField(t.Signature.Id.ToString())}");
            } else {
                sb.AppendLine($"{t.Date.Day + "/" + t.Date.Month + "/" + t.Date.Year} || {FormatField("")} || {FormatField(t.Amount.ToString())} || {FormatField(t.Balance.ToString())} || {FormatField(t.Signature.Id.ToString())}");
            }
            
        }
        return sb;
    }

    private string FormatField(string field)
    {
        return string.IsNullOrEmpty(field) ? "          " : $"{field,-10}";
    }

    public Transaction Withdrawl(int amount)
    {
        Transaction transaction = new Transaction(_id, amount, GetBalance()-amount, TransactionType.DEBIT, _signature);
        _transactions.Add(transaction);
        return transaction;
    }
}

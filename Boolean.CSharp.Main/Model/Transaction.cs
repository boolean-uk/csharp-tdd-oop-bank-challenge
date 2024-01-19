using System.Runtime;

namespace Boolean.CSharp.Main;

public enum TransactionType{
    CREDIT,
    DEBIT
}

public class Transaction {

    private Guid _accountId;
    private DateTime _date;
    private TransactionType _type;
    private int _amount;
    private int _balance;
    private Signature _signature;

    public Transaction(Guid accountId, int amount, int balance, TransactionType type, Signature signature) {
        _accountId = accountId;
        _date = DateTime.Now;
        _amount = amount;
        _balance = balance;
        _type = type;
        _signature = signature;
    }

    public Guid AccountID {get {return _accountId;}}
    public int Amount {get {return _amount;}}
    public int Balance {get {return _balance;}}
    public DateTime Date {get {return _date;}}
    public TransactionType Type {get {return _type;}}
    public Signature Signature {get {return _signature;}}
}
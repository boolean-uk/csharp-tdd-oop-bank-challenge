using System.Runtime;

namespace Boolean.CSharp.Main;

public class Transaction {
    private DateTime _date;
    private int _amount;
    private int _balance;
    private Signature _signature;

    public Transaction(int amount, int balance, Signature signature) {
        _date = DateTime.Now;
        _amount = amount;
        _balance = balance;
        _signature = signature;
    }

    public int Amount {get {return _amount;}}
    public int Balance {get {return _balance;}}
}
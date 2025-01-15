// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;

// IInitializable:  Forces to initialize with initialize function rather than constructor
public abstract class Account : IInitializable 
{
    protected Account() {} // Forbid anyone to create instance
    private int _id;
    private string _accountOwner;
    private string _accountName;
    private Branch _branch;
    private Dictionary<DateTime, Record> records = new Dictionary<DateTime, Record>();
    public int ID { get => _id; }
    public string accountOwner { get =>_accountOwner; }
    public string accountName { get => _accountName; }
    public float GetBalance
        {get { return records.ToList().OrderBy(x => x.Key).Sum(x => x.Value.Amount);}}

    private static void _creationHelper<T>(ref T acc, int accountId, Branch branch, string accountOwner, string accountName)
        where T : Account
    {
        acc._id = accountId;
        acc._branch = branch;
        acc._accountOwner = accountOwner;
        acc._accountName = accountName;
    }
    public static T Create<T>(Bank bank, int accountId, Branch branch, string accountOwner, string accountName)
        where T : Account, new()
    {
        T acc = new T();
        _creationHelper<T>(ref acc, accountId, branch, accountOwner, accountName);

         acc.Initialize(bank, acc);
        return acc; 
    }
    public abstract void Initialize(Bank bank, Account self);
    protected abstract float? handleWithdrawFail(float sumToWithdraw);
    
    public void deposit(float amount)
    {
        Record record = new Record(this, amount, -1, this.ID);
        this.records[record.TransactionDate] = record;
    }

    public float? withdraw(float sumToWithdraw)
    {
        if (GetBalance < sumToWithdraw)
            return handleWithdrawFail(sumToWithdraw);

        Record record = new Record(this, -sumToWithdraw, this.ID, -1);
        this.records[record.TransactionDate] = record;
        return sumToWithdraw;

    }

    internal string getAccountStatement()
    {
        throw new NotImplementedException();
    }
}

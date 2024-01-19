using System.Text;

namespace Boolean.CSharp.Main;

public class PersonalAccount : IAccount
{
    private List<Transaction> _transactions;
    private Branch _branch;
    private Signature _signature;
    private Guid _id;

    public List<Transaction> Transactions => _transactions;
    public Branch Branch => _branch;
    public Signature Signature => _signature;
    public Guid Id => _id;

    public PersonalAccount(Branch branch)
    {
        this._branch = branch;
        this._transactions = new List<Transaction>();
        this._signature = new Signature();
        this._id = Guid.NewGuid();
    }

  
    public StringBuilder PrintReceipt()
    {
        throw new NotImplementedException();
    }

    public Transaction Deposit(int amount)
    {
        throw new NotImplementedException();
    }

    public Transaction Withdrawl(int amount)
    {
        throw new NotImplementedException();
    }

    public int GetBalance()
    {
        throw new NotImplementedException();
    }
}

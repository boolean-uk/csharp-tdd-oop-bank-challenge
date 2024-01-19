using System.Text;

namespace Boolean.CSharp.Main;

public class PersonalAccount : IAccount
{
    public List<Transaction> Transactions => throw new NotImplementedException();

    public Branch Branch => throw new NotImplementedException();

    public Signature Signature => throw new NotImplementedException();

    public Guid Id => throw new NotImplementedException();

    public PersonalAccount(Branch branch) {

    }

    public Transaction Deposit(int amount)
    {
        throw new NotImplementedException();
    }

    public StringBuilder PrintReceipt()
    {
        throw new NotImplementedException();
    }

    public Transaction Withdrawl(int amount)
    {
        throw new NotImplementedException();
    }
}
namespace Boolean.CSharp.Main;

public class Transaction
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType TransactionType { get; private set; }

    public Transaction(decimal amount, TransactionType transactionType)
    {
        TransactionType = transactionType;
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        Amount = amount;
    }
}

namespace Boolean.CSharp.Main.Classes
{
    public class Transaction
    {
        public Guid TransactionId { get; private set; }
        public DateTime Date { get; private set; }
        public string Type { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Balance { get; private set; }

        public Transaction(string type, decimal amount, decimal balance)
        {
            TransactionId = Guid.NewGuid();
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} | {Type,-10} | {Amount:C} | {Balance:C}";
        }
    }
}

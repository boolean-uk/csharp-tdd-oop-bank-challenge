namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public float Amount { get; }
        public string Description { get; }
        public bool IsCredit { get; }
        public DateTime transactionDate { get; }
        public Transaction(float amount, string description, bool isCredit)
        {
            this.Amount = amount;
            this.Description = description;
            this.IsCredit = isCredit;
            this.transactionDate = DateTime.Today;
        }
    }

    public class Overdraft : Transaction
    {
        public Overdraft(float amount, string description) : base(amount, description, false)
        {
        }
    }
}

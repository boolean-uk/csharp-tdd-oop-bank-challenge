namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public float Amount { get; }
        public bool IsCredit { get; }
        public DateTime transactionDate { get; }
        public Transaction(float amount, bool isCredit)
        {
            this.Amount = amount;
            this.IsCredit = isCredit;
            this.transactionDate = DateTime.Today;
        }
    }

    public class Overdraft : Transaction
    {
        public Overdraft(float amount) : base(amount, true)
        {
        }
    }
}

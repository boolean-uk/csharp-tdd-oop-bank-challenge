namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; }
        public double Credit { get; }
        public double Debit { get; }
        public double BalanceAtTransactionTime { get; }
        public Transaction(DateTime date, double credit, double debit, double balance)
        {
            Date = date;
            Credit = credit;
            Debit = debit;
            BalanceAtTransactionTime = balance;
        }
    }
}

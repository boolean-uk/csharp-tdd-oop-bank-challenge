namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; }
        public double Credit { get; }
        public double Debit { get; }
        public Transaction(DateTime date, double credit, double debit)
        {
            Date = date;
            Credit = credit;
            Debit = debit;
        }
    }
}

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; private set; }
        public float Credit { get; private set; }
        public float Debit { get; private set; }


        public Transaction(DateTime date , float credit , float debit)
        {
            Date = date;
            Credit = credit;
            Debit = debit;
        }
    }
}

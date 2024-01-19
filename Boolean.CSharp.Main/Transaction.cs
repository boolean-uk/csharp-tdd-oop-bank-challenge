namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public float Credit { get; set; }
        public float Debit { get; set; }


        public Transaction(DateTime date , float credit , float debit)
        {
            Date = date;
            Credit = credit;
            Debit = debit; ;
        }
    }
}

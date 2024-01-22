namespace Boolean.CSharp.Main
{
    public struct Transaction {
        public DateTime CreationDate;
        public float Amount;
        public Transaction(DateTime creationDate, float amount)
        {
            CreationDate = creationDate;
            Amount = amount;
        }
    }



}

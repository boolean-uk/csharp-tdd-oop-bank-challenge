namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private readonly DateTime _date = DateTime.Now;
        private readonly decimal _credit;
        private readonly decimal _debit;
        private readonly decimal _balance;

        public Transaction(decimal credit, decimal debit, decimal balance)
        {
            _credit = credit;
            _debit = debit;
            _balance = balance + credit - debit;
        }

        public DateTime GetDate() { return _date; }
        public decimal GetCredit() { return _credit; }
        public decimal GetDebit() { return _debit; }
        public decimal GetBalance() { return _balance; }
    }
}

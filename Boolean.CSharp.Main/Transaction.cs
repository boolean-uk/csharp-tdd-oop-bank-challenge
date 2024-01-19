namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _date = DateTime.Now;
        private double _credit;
        private double _debit;
        private double _balance;

        public Transaction(double credit, double debit, double balance)
        {
            _credit = credit;
            _debit = debit;
            _balance = balance;
        }

        public DateTime GetDate() { return _date; }
        public double GetCredit() { return _credit; }
        public double GetDebit() { return _debit; }
        public double GetBalance() { return _balance; }
    }
}

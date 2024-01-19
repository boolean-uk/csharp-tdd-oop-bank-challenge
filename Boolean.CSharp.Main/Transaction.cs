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

        public bool GetCredit()
        {
            throw new NotImplementedException();
        }

        public bool GetDate()
        {
            throw new NotImplementedException();
        }

        public bool GetDebit()
        {
            throw new NotImplementedException();
        }
    }
}

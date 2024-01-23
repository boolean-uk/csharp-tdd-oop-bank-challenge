namespace Boolean.CSharp.Main
{
    public enum TransactionType { Credit, Debit, Overdraft }

    public class Transaction
    {
        private Guid _id;
        private TransactionType _type;
        private DateTime _date;
        private decimal _amount;
        private decimal _previousValue;
        private decimal _newValue;

        public TransactionType Type { get { return _type; } }
        public DateTime Date { get { return _date; } }
        public decimal Amount { get { return _amount; } }
        public decimal PreviousValue { get { return _previousValue; } }
        public decimal NewValue { get { return _newValue; } }


        public Transaction(TransactionType type, decimal amount, decimal previousValue) 
        {
            _id = Guid.NewGuid();
            _type = type;
            _date = DateTime.Now;
            _amount = amount;
            _previousValue = previousValue;

            if(type == TransactionType.Credit)
            {
                _newValue = _previousValue + _amount;
            }
            else
            {
                _newValue = _previousValue - _amount;
            }
            

        }
    }
}

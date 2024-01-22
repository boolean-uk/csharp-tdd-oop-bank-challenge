namespace Boolean.CSharp.Main
{
    public enum TransactionType { Credit, Debit }

    public class Transaction
    {
        private string _id;
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
            //generate id 
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            _id = new string(Enumerable.Range(1, 10).Select(_ => chars[random.Next(chars.Length)]).ToArray());

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

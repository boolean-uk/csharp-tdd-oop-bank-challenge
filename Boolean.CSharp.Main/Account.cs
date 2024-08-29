namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private int _branchcode;
        private float _balance { get { return _transactionHistory.Select(transaction => transaction.Amount).ToArray().Sum(); } }
        private List<Transaction> _transactionHistory = [];
        private float _overdraftLimit = 1000f;
        private string _customerPhoneNumber;
        private IStatement? _statementBuilder;
        private ISMSProvider? _smsprovider;

        public Account(int branchcode, string customerPhoneNumber, IStatement statementBuilder, ISMSProvider smsprovider) : this(branchcode, customerPhoneNumber)
        {
            _branchcode = branchcode;
            _customerPhoneNumber = customerPhoneNumber;
            _statementBuilder = statementBuilder;
            _smsprovider = smsprovider;
        }

        public Account(int branchcode, string customerPhoneNumber)
        {
            _branchcode = branchcode;
            _customerPhoneNumber = customerPhoneNumber;
        }
        public bool Deposit(float amount) 
        {
            if (amount <= 0) return false;
            var transaction = new Transaction(amount, amount+_balance);
            _transactionHistory.Insert(0 ,transaction);
            return true;
        }
        public bool Withdraw(float amount) 
        {
            if (amount <= 0) return false;
            if (_balance < amount) return false;
            var transaction = new Transaction(-amount, _balance-amount);
            _transactionHistory.Insert(0, transaction);
            return true;
        }
        public bool Overdraft(float amount)
        {
            if (amount <= 0) return false;
            if (amount > _overdraftLimit) return false;
            if (_balance <= -_overdraftLimit) return false;
            if (_balance > amount) return false;
            var transaction = new Transaction(amount, _balance - amount);
            _transactionHistory.Add(transaction);
            return true;
        }
        public void GenerateStatement() 
        {
            if (_transactionHistory.Count == 0) 
            {
                Console.WriteLine();
                return;
            }
            string statement = _statementBuilder.GenerateStatement(_transactionHistory);
            _smsprovider.SendSMS(_customerPhoneNumber, statement);
        }
    }
}

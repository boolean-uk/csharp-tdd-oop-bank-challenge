namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private float _branchcode;
        private float _balance { get { return CalculateBalance(); } }
        private List<Transaction> _transactionHistory = [];
        private float _overdraftLimit = 1000f;
        private string _customerPhoneNumber;

        public Account(float branchcode, string customerPhoneNumber)
        {
            _branchcode = branchcode;
            _customerPhoneNumber = customerPhoneNumber;
        }

        private float CalculateBalance() {throw new NotImplementedException(); }
        public bool Deposit(float amount) { throw new NotImplementedException(); }
        public bool Withdraw(float amount) {throw new NotImplementedException();}
        public bool Overdraft(float amount){throw new NotImplementedException();}
        public string GenerateStatement() { throw new NotImplementedException(); }
    }
}

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private string _name;
        private decimal _balance;
        private List<Transaction> _transactions;

        public string Name {  get { return _name; } }
        public decimal Balance { get { return _balance; } }
        public List<Transaction> Transactions { get { return _transactions; } }

        public Account(string name)
        {
            _name = name;
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public string Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public string Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public string GenerateStatement()
        {
            throw new NotImplementedException();
        }
    }
}

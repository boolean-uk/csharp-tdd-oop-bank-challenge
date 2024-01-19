
namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        private Customer _owner;
        private double _balance;
        private List<Transaction> _transactions;
        public Account(Customer owner)
        {
            _owner = owner;
            _balance = 0;
            _transactions = [];
        }

        public Customer GetOwner()
        {
            return _owner;
        }

        public double GetBalance()
        {
            return Math.Round(_balance, 2);
        }

        public abstract AccountTypes GetAccountType();

        public Customer GetAccountOwner()
        {
            return _owner;
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                CreateTransaction(amount, 0);
                return true;
            };
            return false;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= GetBalance())
            {
                _balance -= amount;
                CreateTransaction(0, amount);
                return true;
            };
            return false;
        }

        private void CreateTransaction(double credit, double debit)
        {
            Transaction transaction = new(credit, debit, _balance);
            _transactions.Add(transaction);
        }

        public List<Transaction> GenerateBankStatement()
        {
            return _transactions;
        }
    }
}

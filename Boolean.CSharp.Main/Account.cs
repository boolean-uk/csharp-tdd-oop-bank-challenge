
namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        AccountTypes GetAccountType();
        double GetBalance();
        Customer GetAccountOwner();
        bool Deposit(double amount);
        bool Withdraw(double amount);
    }
    public abstract class Account : IAccount
    {
        private Customer _owner;
        private double _balance;
        public Account(Customer owner)
        {
            _owner = owner;
            _balance = 0;
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
                return true;
            };
            return false;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= GetBalance())
            {
                _balance -= amount;
                return true;
            };
            return false;
        }
    }
}


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
            throw new NotImplementedException();
        }

        public abstract AccountTypes GetAccountType();

        public Customer GetAccountOwner()
        {
            throw new NotImplementedException();
        }

        public bool Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public bool Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}

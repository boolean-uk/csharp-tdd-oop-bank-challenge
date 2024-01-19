
namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        AccountTypes GetAccountType();
        bool GetBalance();
    }
    public abstract class Account : IAccount
    {
        public Customer Owner { get; set; }

        public Account(Customer owner)
        {
            Owner = owner;
        }


        public bool GetBalance()
        {
            throw new NotImplementedException();
        }

        public abstract AccountTypes GetAccountType();
    }
}

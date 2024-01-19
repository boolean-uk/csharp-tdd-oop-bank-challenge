namespace Boolean.CSharp.Main
{
    public class User
    {
        public readonly List<Account> accounts;

        public User()
        {
            accounts = new List<Account>();
        }

        public void CreateCurrent()
        {
            accounts.Add(new CurrentAccount());
        }

        public void CreateSavings()
        {
            accounts.Add(new SavingsAccount());
        }
    }
    public class Account
    {

    }

    public class CurrentAccount : Account
    {

    }
    public class SavingsAccount : Account
    {

    }
}

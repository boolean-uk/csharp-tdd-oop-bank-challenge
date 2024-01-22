

using Boolean.CSharp.Main.Accounts;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private readonly List<Account> _accounts = [];
        private readonly SmsService _msService = new();

        public Account? CreateAccount(Customer customer, AccountTypes accountType, AccountBranches ab)
        {
            if (customer == null) return null;

            Account account;
            if (accountType == AccountTypes.Current)
            {
                account = new CurrentAccount(customer, ab, _msService);
                _accounts.Add(account);
            }
            else
            {
                account = new SavingsAccount(customer, ab, _msService);
                _accounts.Add(account);
            }
            return account;
        }

        public List<Account> GetAccounts(Customer customer)
        {
            return _accounts.Where(x => x.GetOwner() == customer).ToList();
        }
    }
}

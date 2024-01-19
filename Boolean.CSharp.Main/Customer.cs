namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public List<Account> Accounts { get; private set; }

        public Customer()
        {
            Accounts = new List<Account>();
        }

        public CurrentAccount CreateCurrentAccount()
        {
            var account = new CurrentAccount(Accounts.Count + 1);
            Accounts.Add(account);
            return account;
        }

        public SavingsAccount CreateSavingsAccount()
        {
            var account = new SavingsAccount(Accounts.Count + 1);
            Accounts.Add(account);
            return account;
        }

        public BankStatement GenerateBankStatement(int accountId)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);
            if(account == null) return null;

            return new BankStatement(account.Transactions);
        }
    }
}
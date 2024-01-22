namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public List<Account> Accounts { get; private set; }

        public Customer()
        {
            Accounts = new List<Account>();
        }

        public CurrentAccount CreateCurrentAccount(Branch branch)
        {
            var account = new CurrentAccount(Accounts.Count + 1 , branch);
            Accounts.Add(account);
            return account;
        }

        public SavingsAccount CreateSavingsAccount(Branch branch)
        {
            var account = new SavingsAccount(Accounts.Count + 1 , branch);
            Accounts.Add(account);
            return account;
        }

        public BankStatement GenerateBankStatement(int accountId)
        {
            var account = Accounts.FirstOrDefault(a => a.GetId() == accountId);
            if(account == null)
            {
                Console.WriteLine("Account does not exist.");
                return null;
            }

            return new BankStatement(account.Transactions);
        }
    }
}
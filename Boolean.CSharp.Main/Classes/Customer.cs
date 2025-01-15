namespace Boolean.CSharp.Main.Classes
{
    public class Customer : Person
    {
        public Guid CustomerId { get; private set; }
        public List<Account> Accounts { get; private set; }
        public Bank Bank { get; private set; }
        public string Branch => Bank.Branch;

        public Customer(string firstName, string lastName, string email, string address, Bank bank)
            : base(firstName, lastName, email, address)
        {
            CustomerId = Guid.NewGuid();
            Accounts = new List<Account>();
            Bank = bank;
        }

        public void CreateAccount(string accountType)
        {
            var account = new Account(accountType, this, Bank.Branch);
            Accounts.Add(account);
            Console.WriteLine($"Account created for {accountType} account under {Bank.Branch} branch!");
        }

        public override string ToString()
        {
            string baseInfo = base.ToString();
            string accountsInfo = Accounts.Any()
                ? string.Join(", ", Accounts.Select(a => a.AccountType + " (" + a.Branch + ")"))
                : "No accounts created yet.";

            return baseInfo + $"\nBranch: {Branch}\nBank: {Bank.Name}\nAccounts: {accountsInfo}";
        }
    }
}

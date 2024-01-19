namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        public string Name { get; set; }
        public double Balance { get; }
        public void GenerateBankStatements();
        public bool Deposit(double amount);
        public double Withdraw(double amount);
    }
}

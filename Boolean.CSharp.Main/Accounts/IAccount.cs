namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        public string Name { get; set; }
        public double Balance { get; }
        public List<BankStatement> BankStatements { get; }
        public void GenerateBankStatements(double amount);
        public void Deposit(double amount);
        public double Withdraw(double amount);
    }
}

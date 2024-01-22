using Boolean.CSharp.Main.Branches;

namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        public string Name { get; }
        public double Balance { get; }
        public IBranch Branch { get; }
        public List<BankStatement> BankStatements { get; }
        public void GenerateBankStatements(double amount);
        public void PrintBankStatements();
        public void Deposit(double amount);
        public double Withdraw(double amount);
    }
}

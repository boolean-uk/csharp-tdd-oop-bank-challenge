using Boolean.CSharp.Main.Accounts;

namespace Boolean.CSharp.Test
{
    public class Branch
    {
        public List<BankAccount> accounts { get; internal set; } = new List<BankAccount>();

        internal void AddAccount(SavingsAccount savingsAccount)
        {
            throw new NotImplementedException();
        }


    }
}
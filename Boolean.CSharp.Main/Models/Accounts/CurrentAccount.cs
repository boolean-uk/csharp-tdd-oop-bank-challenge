using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public class CurrentAccount : Account
    {
        public double OverdraftLimit { get; private set; }

        public CurrentAccount(Branch branch, string phoneNumber) : base(branch, phoneNumber)
        {
            OverdraftLimit = 0;
        }

        public void RequestOverdraft(double amount, OverdraftManager overdraftManager)
        {
            overdraftManager.CreateRequest(AccountNumber, amount);
        }
    }
}
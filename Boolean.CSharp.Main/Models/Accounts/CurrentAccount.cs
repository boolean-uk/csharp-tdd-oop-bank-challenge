using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public class CurrentAccount : Account
    {
        public double OverdraftLimit { get; set; }

        public CurrentAccount(Branch branch, string phoneNumber) : base(branch, phoneNumber)
        {
            OverdraftLimit = 0;
        }

        public void RequestOverdraft(double amount, OverdraftManager overdraftManager)
        {
            overdraftManager.CreateRequest(AccountNumber, amount);
        }

        public override void Withdraw(double amount)
        {
            if (amount > Balance + OverdraftLimit)
                throw new InvalidOperationException("Cannot withdraw this amount, because it would exceed overdraft limit.");

            Transaction transaction = new Transaction(amount, TransactionType.Debit);
            Transactions.Add(transaction);
        }

    }
}
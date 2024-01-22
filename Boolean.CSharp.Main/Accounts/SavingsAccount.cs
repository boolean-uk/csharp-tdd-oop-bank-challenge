namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount(Customer customer, AccountBranches ab) : Account(customer, ab)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Savings;
        }
    }
}
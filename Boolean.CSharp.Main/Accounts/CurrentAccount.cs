namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount(Customer customer, AccountBranches ab) : Account(customer, ab)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Current;
        }
    }
}
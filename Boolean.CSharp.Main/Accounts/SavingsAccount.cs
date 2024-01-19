namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount(Customer customer) : Account(customer)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Savings;
        }
    }
}
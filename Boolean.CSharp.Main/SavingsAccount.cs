namespace Boolean.CSharp.Main
{
    public class SavingsAccount(Customer customer) : Account(customer)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Savings;
        }
    }
}
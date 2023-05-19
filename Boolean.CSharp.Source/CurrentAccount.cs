namespace Boolean.CSharp.Source
{
    public class CurrentAccount
    {
        public decimal balance;

        public decimal DepositMoney(decimal deposit)
        {
            balance=+ deposit;
            return balance;
        }
    }
}
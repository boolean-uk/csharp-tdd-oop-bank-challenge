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

        public decimal WithdrawMoney(decimal withdraw)
        {
            balance=+withdraw;
            return balance;
        }
    }
}
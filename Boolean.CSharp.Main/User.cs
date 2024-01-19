namespace Boolean.CSharp.Main
{
    public class User
    {
        public Account CreateCurrent()
        {
            return new CurrentAccount();
        }

        public Account CreateSavings()
        {
            return new SavingsAccount();
        }
    }
    public class Account
    {
        private float balance = 0f;
        //private List<Transaction> transactions;

        public float GetBalance()
        {
            return balance;
        }

        public bool DepositMoney(float amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WithdrawMoney(float amount)
        {
            if (amount <= balance && amount > 0)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class CurrentAccount : Account
    {

    }
    public class SavingsAccount : Account
    {

    }

    public struct Transaction
    {
        public float Amount { get; }
        public float balance { get; }
        public bool IsCredit { get; }
        public DateOnly transactionDate { get; }
        public Transaction(float amount, float balance, bool isCredit)
        {
            this.Amount = amount;
            this.balance = balance;
            this.IsCredit = isCredit;
            this.transactionDate = new DateOnly();

        }
    }
}

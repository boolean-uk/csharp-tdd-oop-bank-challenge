namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        public double Balance { get; private set; }
        private List<Transaction> accounts = new List<Transaction>();

        public void Deposit(double amount, DateTime date)
        {
            Balance += amount;
        }

        public void Withdraw(double amount, DateTime date)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("You don't have enough funds on account");
            }
            Balance -= amount;
        }

        public string PrintStatement()
        {
            throw new NotImplementedException();
        }


    }
}

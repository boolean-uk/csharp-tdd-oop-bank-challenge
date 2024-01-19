namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public int Id { get; set; }
        public float Balance { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        protected Account(int id)
        {
            Id = id;
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public bool Deposit(float amount)
        {
            if(amount <= 0) return false;

            Balance += amount;
            Transactions.Add(new Transaction(DateTime.Now , amount , 0 , Balance));
            return true;
        }

        public bool Withdraw(float amount)
        {
            if(amount <= 0 || amount > Balance) return false;

            Balance -= amount;
            Transactions.Add(new Transaction(DateTime.Now , 0 , amount , Balance));
            return true;
        }

        public float ViewBalance()
        {
            return Balance;
        }
    }
}

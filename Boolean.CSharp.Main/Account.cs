namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public int Id { get; private set; }
        private Branch Branch { get; set; }
        public List<Transaction> Transactions { get; private set; }

        public int GetId()
        {
            return Id;
        }

        public Branch GetBranch()
        {
            return Branch;
        }

        protected Account(int id , Branch branch)
        {
            Id = id;
            Branch = branch;
            Transactions = new List<Transaction>();
        }

        public bool Deposit(float amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            Transactions.Add(new Transaction(DateTime.Now , amount , 0));
            return true;
        }

        public virtual bool Withdraw(float amount)
        {
            float balance = ViewBalance();
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if(amount > balance)
            {
                throw new ArgumentException("Insufficient balance for withdrawal.");
            }

            Transactions.Add(new Transaction(DateTime.Now , 0 , amount));
            return true;
        }

        public float ViewBalance()
        {
            float balance = 0;
            foreach(var transaction in Transactions)
            {
                balance += transaction.Credit;
                balance -= transaction.Debit;
            }
            return balance;
        }
    }
}

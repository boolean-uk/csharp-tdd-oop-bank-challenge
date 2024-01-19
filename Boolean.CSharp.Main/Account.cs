namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public int Id { get; set; }
        public Branch Branch { get; set; } //Added for extension
        public List<Transaction> Transactions { get; private set; }

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
                Console.WriteLine("Deposit amount must be greater than zero.");
                return false;
            }

            Transactions.Add(new Transaction(DateTime.Now , amount , 0));
            return true;
        }

        public bool Withdraw(float amount)
        {
            float balance = ViewBalance();
            if(amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return false;
            }
            if(amount > balance)
            {
                Console.WriteLine("Insufficient balance for withdrawal.");
                return false;
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

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public float OverdraftLimit { get; set; }
        public CurrentAccount(int id , Branch branch) : base(id , branch) { }

        public override bool Withdraw(float amount)
        {
            float balance = ViewBalance() + OverdraftLimit;
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
    }
}

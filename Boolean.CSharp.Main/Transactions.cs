namespace Boolean.CSharp.Main
{
    public class Transactions
    {
        private float _amount;
        private Account _account;
        public Account Account { get{ return _account; } }
        public float Amount { get { return _amount; } }

        public Transactions(float amount, Account account)
        {
            this._amount = amount;
            this._account = account;
        }

        public string getTransaction()
        {
            return $"{getTransactionAction()} from acount {Account.accountNumber}";
        }

        private string getTransactionAction()
        {
            if (Amount > 0)
            {
                return "Deposited";
            }
            return "Withdrew";
        }

    }
}
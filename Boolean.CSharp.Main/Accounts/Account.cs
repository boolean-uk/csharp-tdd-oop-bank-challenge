


namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        private Customer _owner;
        private List<Transaction> _transactions;
        private AccountBranches _branch;
        private List<Overdraft> _overdrafts;
        public Account(Customer owner, AccountBranches ab)
        {
            _owner = owner;
            _transactions = [];
            _overdrafts = [];
            _branch = ab;
        }

        public Customer GetOwner()
        {
            return _owner;
        }

        public decimal GetBalance()
        {
            return _transactions.Count > 0 ? _transactions.Last().GetBalance() : 0;
            // Alternative method of calculating that does not rely on storing balance in Transaction:
            // return Math.Round(_transactions.Sum(x => x.GetCredit() - x.GetDebit()), 2); 
        }

        public abstract AccountTypes GetAccountType();

        public Customer GetAccountOwner()
        {
            return _owner;
        }

        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                CreateTransaction(amount, 0);
                return true;
            };
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= GetBalance())
            {
                CreateTransaction(0, amount);
                return true;
            };
            Overdraft o = new(amount - GetBalance());
            _overdrafts.Add(o);
            return false;
        }

        public void CreateTransaction(decimal credit, decimal debit)
        {
            Transaction transaction = new(credit, debit, GetBalance());
            _transactions.Add(transaction);
        }

        public List<Transaction> GenerateBankStatement()
        {
            return _transactions;
        }

        public void PrintBankStatement()
        {
            Console.WriteLine("date       || credit  || debit   || balance\n------------------------------------------");
            foreach (Transaction t in _transactions)
            {
                if (t.GetCredit() == 0)
                {
                    Console.WriteLine($"{t.GetDate().ToShortDateString()} ||         || {t.GetDebit()}    || {t.GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"{t.GetDate().ToShortDateString()} || {t.GetCredit()}   ||         || {t.GetBalance()}");
                }

            }
        }

        public AccountBranches GetBranch()
        {
            return _branch;
        }

        public List<Overdraft> GetOverdraftRequests()
        {
            return _overdrafts;
        }
    }
}

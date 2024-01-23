using System.Text;  

namespace Boolean.CSharp.Main
{
    public enum Branch { Norway, Sweden, Denmark}
    public class Account
    {
        private string _name;
        //private decimal _balance;
        private List<Transaction> _transactions;
        private List<Overdraft> _overdrafts;
        private Branch _branch;

        public string Name {  get { return _name; } }
        //public decimal Balance { get { return _balance; } }
        public List<Transaction> Transactions { get { return _transactions; } }
        public List<Overdraft> Overdrafts {  get { return _overdrafts; } }
        public Branch Branch { get { return _branch; } }


        public Account(string name, Branch branch)
        {
            _name = name;
            //_balance = 0;
            _transactions = new();
            _branch = branch;
            _overdrafts = new();
        }

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (Transaction transaction in _transactions)
            {
                if (transaction.Type == TransactionType.Credit)
                {
                    balance += transaction.Amount;
                }
                else
                {
                    balance -= transaction.Amount;
                }
            }
            return balance;
        }

        public string Deposit(decimal amount)
        {
            _transactions.Add(new(TransactionType.Credit, amount, GetBalance()));
            return $"{amount} deposited to {_name}, new balance is {GetBalance()}";
        }

        public string Withdraw(decimal amount)
        {
            Transaction withdrawal = new(TransactionType.Debit, amount, GetBalance());
            if (withdrawal.NewValue < 0) 
            {
                return $"Cannot withdraw from {_name}, balance is less than withdrawal amount";
            }
            _transactions.Add(withdrawal);
            return $"{amount} withdrawn from {_name}, new balance is {GetBalance()}";
        }

        public string GenerateStatement()
        {
            StringBuilder sb = new();
            sb.AppendFormat("|{0,-10}| {1,-7}| {2,-7}| {3,-7}|\n", "date", "credit", "debit", "balance");
            foreach(Transaction transaction in _transactions.OrderByDescending(t => t.Date))
            {
                if (transaction.Type == TransactionType.Credit)
                {
                    sb.AppendFormat("|{0,-10}| {1,-7}| {2,-7}| {3,-7}|\n", transaction.Date.ToString("dd/MM/yyyy"), transaction.Amount, 0, transaction.NewValue);
                }
                else
                {
                    sb.AppendFormat("|{0,-10}| {1,-7}| {2,-7}| {3,-7}|\n", transaction.Date.ToString("dd/MM/yyyy"), 0, transaction.Amount, transaction.NewValue);
                }
            }

            return sb.ToString();
        }

        public void RequestOverdraft(decimal amount)
        {
            _overdrafts.Add(new(amount));
        }

        public string AcceptOverdraft(Overdraft overdraft)
        {
            _transactions.Add(new(TransactionType.Overdraft, overdraft.Amount, GetBalance()));
            _overdrafts.Remove(overdraft);
            return $"overdraft has been accepted, new balance is {GetBalance()}";
        }

        public string RejectOverdraft(Overdraft overdraft) 
        {
            _overdrafts.Remove(overdraft);
            return "overdraft has been rejected";
        }

    }
}

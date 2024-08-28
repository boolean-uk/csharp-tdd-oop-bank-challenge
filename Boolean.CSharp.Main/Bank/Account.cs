using System.Text;

namespace Boolean.CSharp.Main.Bank
{
    public abstract class Account
    {
        private List<Account> _myAccounts = new List<Account>();
        private List<Transaction> _transactions = new List<Transaction>();
        private StringBuilder _bankStatement = new StringBuilder();
        private string _accountType = "";
        private decimal _amount;

        private StringBuilder GenerateBankStatement()
        {
            _bankStatement.AppendLine("|| date                   || credit    || debit     || balance  ");


            _transactions.Reverse();

            foreach (Transaction t in _transactions)
            {

                if (t.TransactionType == "deposit")
                {
                    _bankStatement.AppendLine($"|| {t.Date}    || {t.Amount}   ||           || {t.Balance}");
                }
                if (t.TransactionType == "withdraw")
                {
                    _bankStatement.AppendLine($"|| {t.Date}    ||           || {t.Amount}    || {t.Balance}");
                }

            }
            return _bankStatement;
        }

        public bool AddAccount(Account account)
        {
            _accountType = account.AccountType;

            if (_accountType == "Current")
            {
                _myAccounts.Add(account);
                return true;
            }
            if (_accountType == "Savings")
            {
                _myAccounts.Add(account);
                return true;
            }
            return false;
        }

        public bool MakeDeposit(decimal amount)
        {
            _amount = amount;
            

            if (_amount > 0)
            {
                Transaction transaction = new Transaction(_amount, DateTime.Now, GetBalance() + _amount, "deposit");
                _transactions.Add(transaction);
                return true;
            }
            return false;

        }

        public bool MakeWithdrawal(decimal amount)
        {
            _amount = amount;

            if (GetBalance() > _amount)
            {
                Transaction transaction1 = new Transaction(_amount, DateTime.Now, GetBalance() - _amount, "withdraw");
                _transactions.Add(transaction1);
                return true;
            }
            return false;
        }

        public decimal GetBalance()
        {
            decimal _getbalance = 0;

            foreach (var transaction in _transactions)
            {
                if (transaction.TransactionType == "deposit")
                {
                    _getbalance += transaction.Amount;
                }

                if (transaction.TransactionType == "withdraw")
                {
                    _getbalance -= transaction.Amount;
                }

            }
            return _getbalance;
        }

        public string AccountType { get { return _accountType; } set { _accountType = value; } }
        public virtual string BranchName { get; set; }
        public List<Account> MyAccounts { get { return _myAccounts; } }
        public List<Transaction> MyTransactions { get { return _transactions; } }
        public string PrintBankStatement { get { return GenerateBankStatement().ToString(); } }


    }
}

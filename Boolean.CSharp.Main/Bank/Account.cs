using System.Text;

namespace Boolean.CSharp.Main.Bank
{
    public abstract class Account
    {
        private List<Account> _myAccounts = new List<Account>();
        private List<Transaction> _transactions = new List<Transaction>();
        private StringBuilder _bankStatement = new StringBuilder();
        
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
                if (t.TransactionType == "overdraft")
                {
                    _bankStatement.AppendLine($"|| {t.Date}    ||           || {t.Amount}    || {t.Balance}");
                }

            }
            return _bankStatement;
        }

        public bool AddAccount(Account account)
        {
            
            if (account.AccountType == "Current")
            {
                _myAccounts.Add(account);
                return true;
            }
            if (account.AccountType == "Savings")
            {
                _myAccounts.Add(account);
                return true;
            }
            return false;
        }

        public bool MakeDeposit(decimal amount)
        {
            if (amount > 0)
            {
                Transaction transaction = new Transaction(amount, DateTime.Now, GetBalance() + amount, "deposit");
                _transactions.Add(transaction);
                return true;
            }
            return false;

        }

        public bool MakeWithdrawal(decimal amount)
        {
            if (GetBalance() > amount)
            {
                Transaction transaction1 = new Transaction(amount, DateTime.Now, GetBalance() - amount, "withdraw");
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

        public bool MakeOverdraft(decimal amount, bool approval)
        {
            if(GetBalance() < amount && approval) 
            {
                Transaction transaction1 = new Transaction(amount, DateTime.Now, GetBalance() - amount, "overdraft");
                _transactions.Add(transaction1);
                return true;
            }
            return false;
        }

        public string AccountType { get; set; }
        public virtual string BranchName { get; set; }
        public List<Account> MyAccounts { get { return _myAccounts; } }
        public List<Transaction> MyTransactions { get { return _transactions; } }
        public string PrintBankStatement { get { return GenerateBankStatement().ToString(); } }

    }
}

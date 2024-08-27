
using System.Security.Principal;

namespace Boolean.CSharp.Main.Bank
{
    public abstract class Account : ITransaction
    {
        private List<Account> _myAccounts = new List<Account>();
        private List<Transaction> _transactions = new List<Transaction>();

        private string _accountType = "";
        private decimal _balance;
        private decimal _amount;
        private DateTime _date;

        public bool CreateAccount(Account account)
        {
            _accountType = account.AccountType;
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
            _amount = amount;
            _date = Date;

            if (_amount > 0)
            {
                Transaction transaction = new Transaction(_amount, _date);
                _transactions.Add(transaction);
                _balance += _amount;
                return true;
            }
            return false;

        }

        public bool MakeWithdrawal(decimal withdrawAmount)
        {
            throw new NotImplementedException();
        }

        public string AccountType { get { return _accountType; } set { _accountType = value; } }
        public List<Account> MyAccounts { get { return _myAccounts; } }

        public List<Transaction> MyTransactions { get { return _transactions; } }

        public decimal Balance { get { return _balance; } }

        public decimal Amount { get { return _amount; } }

        public DateTime Date { get { return DateTime.Now; } }
    }
}

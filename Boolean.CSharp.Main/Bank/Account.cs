
using System.Security.Principal;
using System.Text;

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
                _balance += _amount;
                Transaction transaction = new Transaction(_amount, _date, _balance);
                _transactions.Add(transaction);
                return true;
            }
            return false;

        }

        public bool MakeWithdrawal(decimal amount)
        {
            _amount = amount;
            _date = Date;

            if (_balance > _amount)
            {
                _balance -= _amount;
                Transaction transaction1 = new Transaction(_amount, _date, _balance);
                _transactions.Add(transaction1);
                return true;
            }
            return false;
        }

        public string AccountType { get { return _accountType; } set { _accountType = value; } }
        public List<Account> MyAccounts { get { return _myAccounts; } }

        public List<Transaction> MyTransactions { get { return _transactions; } }

        public bool Print { get; set; }

        public decimal Balance { get { return _balance; } }

        public decimal Amount { get { return _amount; } }

        public DateTime Date { get { return DateTime.Now; } }
    }
}

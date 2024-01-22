using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        //private static int _accountCounter = 0;     //To keep track of how many acc we have created.
        protected Enums _Type;
        private double _Balance = 0;
        private List<Transaction> _transactions = new List<Transaction>();


        public Guid _AccId { get; set; }

        public bool _IsAccActive { get; set; } = true;
        public Branches _Branch { get; }


        public Account(Branches branch)
        {
            _Branch = branch;

            //int accountIdSuffix = System.Threading.Interlocked.Increment(ref _accountCounter);
            //Generates the uniq account ID
            _AccId = Guid.NewGuid();


        }

        public double getBlance()
        {
            return _Balance;
        }

        public void Deposit(Transaction transaction)
        {
            _transactions.Add(transaction);
            transaction.TransectionStatus = true;
            transaction.NewBalance = _Balance + transaction.Amount;
            _Balance += transaction.Amount;
            
        }

        public void Withdraw(Transaction transaction)
        {
            _transactions.Add(transaction);
            if (_Balance >= transaction.Amount)
            {
                transaction.TransectionStatus = true;
                transaction.NewBalance = _Balance - transaction.Amount;
                _Balance -= transaction.Amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds for withdraw.");
            }
        }

        public List<Transaction> getOverview()
        {
            return _transactions;
        }

        public bool getAccountStatus()
        {
            return _IsAccActive;
        }

        public string writeStatement()
        {   
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance"));
            foreach (Transaction transaction in _transactions.OrderByDescending(t => t.DateInfo).Where(t => t.TransectionStatus == true))
            {
                sb.Append(string.Format("{0,10} || {1,10} || {2,10} || {3,10} "
                    , transaction.DateInfo.ToShortDateString()
                    , transaction.Type == TransactionType.Deposit ? transaction.Amount : 0
                    , transaction.Type == TransactionType.Withdraw ? transaction.Amount : 0
                    , transaction.NewBalance
                    ));
                
            }
            Console.WriteLine(sb.ToString());
            return (sb.ToString());
        }
    }
}

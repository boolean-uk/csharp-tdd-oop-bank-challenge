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
        private static int _accountCounter = 0;     //To keep track of how many acc we have created.
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
            _Balance += transaction.Amount;
            transaction.TransectionStatus = true;
        }

        public void Withdraw(Transaction transaction)
        {
            _transactions.Add(transaction);
            if (_Balance >= transaction.Amount)
            {
                _Balance -= transaction.Amount;
                transaction.TransectionStatus = true;
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
    }
}

using Boolean.CSharp.Main.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.CoreFiles;
using Boolean.CSharp.Main.Users;
using System.Security.Principal;

namespace Boolean.CSharp.Main.CoreFiles
{
    public abstract class Account
    {
        public Guid ID { get; } = Guid.NewGuid();
        public Bank BankRef { get; protected set; }
        public User OwnerRef { get; protected set; }
        public List<Transaction> TransactionHistory { get; protected set; } = new List<Transaction>();
        public List<Overdraft> Overdrafts = new List<Overdraft>();
        private string _mobileNumber = "";
        private double _money = 0;

        public Account(Bank bank, User user, MobilePhone mobile = null)
        {
            OwnerRef = user;
        }

        public double GetBalance()
        {
            return TransactionHistory.Sum(x => x.Amount);
        }

        public List<Transaction> GetBankStatements() 
        {
            return TransactionHistory;
        }

        public bool SetPhoneNumber(string mobileNumber)
        {
            if (mobileNumber == "")
                return false;

            _mobileNumber  = mobileNumber;
            return true;
        }

        public bool Deposit(double moneyAmount)
        {
            if(OwnerRef.Money < moneyAmount || moneyAmount < 0)
                return false;

            _money += moneyAmount;
            OwnerRef.Money -= moneyAmount;

            Transaction transaction = new Transaction(StatementType.Deposit, moneyAmount, GetBalance());
            TransactionHistory.Add(transaction);
            SendTransactionSMS(transaction);

            return true;
        }

        public bool Withdraw(double moneyAmount)
        {
            double overdraftAmount = 0;

            if (Overdrafts.Count() > 0) {

                // Check for overdraft
                List<Overdraft> overdrafts = Overdrafts.Where(x => x.OverdraftState == OverdraftState.Accepted).ToList();
                overdrafts = overdrafts.OrderBy(x => x.DateTime).ToList();
                Overdraft overdraft = null;
                if (overdrafts.Count() > 0)
                    overdraft = overdrafts.First();

                if (overdraft != default(Overdraft) || overdraft != null)
                    overdraftAmount = overdraft.RequestedAmount;
            }




            // Reduce money
            if (_money - moneyAmount < 0 - overdraftAmount)
                return false;

            OwnerRef.Money += moneyAmount;
            _money -= moneyAmount;

            TransactionHistory.Add(new Transaction(StatementType.Withdraw, -moneyAmount, GetBalance()));

            return true;
        }

        public bool RequestOverdraft(double requestedAmount)
        {
            if(requestedAmount < 0) 
                return false;

            Overdrafts.Add(new Overdraft(ID, requestedAmount));
            return true;
        }

        private bool SendTransactionSMS(Transaction transaction)
        {
            if (_mobileNumber == "")
                return false;

            string transactionStr;
            transactionStr =  $"{transaction.dateTime.ToString("dd:mm:yyyy")} {transaction.dateTime.ToString("hh:mm")}";
            transactionStr += $"You {transaction.StatementType.ToString().ToLower()}ed {transaction.Amount} to your account {ID}.\n";
            transactionStr = $"Balance at time of transaction: {transaction.balanceAtTransaction}\n";


            BankRef.SendMessage(_mobileNumber, transactionStr);
            return true;
        }
    }
}

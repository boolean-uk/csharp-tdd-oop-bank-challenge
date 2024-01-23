using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{

    public enum AccountType {
        CURRENT = 1,
        SAVINGS = 2,
    }
    public abstract class Account : IAccount
    {
        public string AccountName { get; private set;}
        public int ID { get; private set; }
        public Branch AccountBranch { get; private set; }
        private List<Transaction> _transactions;
        private int lastUsedID = 0;

        public Account(string accountname, decimal balance, Branch accosiatedBranch) {
            ID = GetId();
            _transactions = new List<Transaction>();
            if (!string.IsNullOrEmpty(accountname)) {
                AccountName = accountname;
            } else {
                throw new Exception("You can not have an empty account name");
            }
            

            if (balance > 0) {
                AddTransaction(balance, TransactionType.DEPOSIT);
            } else {
                throw new Exception($"{balance} is not a valid starting balence, the balance must be 0 or greater");
            }

            if (!string.IsNullOrEmpty(accosiatedBranch.ToString())) {
                AccountBranch = accosiatedBranch;
            } else {
                throw new Exception("No entered branch");
            }

            
        }

        private int GetId()
        {
            return ++lastUsedID;
        }

        public void Deposit(decimal amount) {
            if (amount > 0) {
                //Balance += amount;
                
                AddTransaction(amount, TransactionType.DEPOSIT);
            } else {
                throw new InvalidOperationException($"{amount} is not a Deposit amount our bank accepts, the deposit amount needs to be greater than 0");
            }
            
            
        }

        
        public void Withdraw(decimal amount) {
            decimal balance = CalculateAccountBalance();
            if (balance >= amount && amount > 0) {
                //Balance -= amount;
                AddTransaction(amount, TransactionType.WITHDRAW);
            } else {
                throw new InvalidOperationException($"This account have insufficient funds to make the transation on {amount} since the balance is {CalculateAccountBalance()}");
            }
            
            
        }

        public string GenerateStatement() {
            string statement = $"statement from {AccountName}";
            if (_transactions.Count <= 0) {
                return $"\nNo transaction history for account: {AccountName}";
            }
            statement += "\nDate    ||    Withdraw    ||    Deposit   || Balance";
            decimal currentBalance = 0m;
            foreach (Transaction transation in _transactions) {
                if (transation.Type == TransactionType.DEPOSIT) { // Extension
                    currentBalance += transation.Amount; // Extension
                } else if (transation.Type == TransactionType.WITHDRAW) { // Extension
                    currentBalance -= transation.Amount; // extension
                }
                
                string date = transation.DateOfTransaction;
                string withdraw = transation.Type == TransactionType.WITHDRAW ? transation.Amount.ToString("F2") : "0,00";
                string deposit = transation.Type == TransactionType.DEPOSIT ? transation.Amount.ToString("F2") : "0,00";
                statement += $"\n{date}    ||   {withdraw}    ||    {deposit}     ||    {currentBalance}"; 

            }
            return statement; 
        }

        private void AddTransaction(decimal amount, TransactionType type) {
            var transation = new Transaction(amount, type, this);
            _transactions.Add(transation);
        } 

        public abstract AccountType GetAccountType();

        public int GetTransactionListCount() {
            return _transactions.Count;
        }
        
        // Extension
        public decimal CalculateAccountBalance() {
            decimal accounBalance = 0m;
            foreach (Transaction transaction in _transactions) {
                if (transaction.Type == TransactionType.DEPOSIT) {
                    accounBalance += transaction.Amount;
                } else { // We know it to be a withdraw
                    accounBalance -= transaction.Amount;
                }
            }

            return accounBalance;
        }
        
        // Extension
        public string PhoneNotification(int phonenumber) {
            
            // Logic ?? 

            return "statement";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static Boolean.CSharp.Main.Extension;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        public class Transaction
        {
            public string Type { get; }
            public double Amount { get; }
            public DateTime Date { get; }
            public double Balance { get; }

            public Transaction(string type, double amount, DateTime date, double balance)
            {
                Type = type;
                Amount = amount;
                Date = date;
                Balance = balance;
            }
        }

        public class BankAccount
        {
            private string accountHolder;
            private string accountNumber;
            private string accountType;
            private List<Transaction> transactionList;

            public BankAccount(string accountHolder, string accountNumber, string accountType)
            {
                this.accountHolder = accountHolder;
                this.accountNumber = accountNumber;
                this.accountType = accountType;
                this.transactionList = new List<Transaction>();
            }

            public string AccountHolder => accountHolder;
            public string AccountNumber => accountNumber;
            public string AccountType => accountType;

            public List<Transaction> TransactionList => transactionList;

            public double GetBalance
            {
                get
                {
                    double calculatedBalance = 0;
                    foreach (var transaction in transactionList)
                    {
                        if (transaction.Type == "Deposit")
                        {
                            calculatedBalance += transaction.Amount;
                        }
                        else if (transaction.Type == "Withdrawal")
                        {
                            calculatedBalance -= transaction.Amount;
                        }
                    }
                    return calculatedBalance;
                }
            }
        }

            public class BankAffiliate
        {
            private string fullName;
            private string affiliation;
            private List<BankAccount> bankAccountList;
            private List<Transaction> transactionList;
            public List<Transaction> TransactionList => transactionList;

            public BankAffiliate()
            {
                this.transactionList = new List<Transaction>();
            }

            public BankAffiliate(string fullName, string affiliation)
            {
                this.fullName = fullName;
                this.affiliation = affiliation;
                this.bankAccountList = new List<BankAccount>();
            }

            public BankAffiliate(string fullName, string affiliation, List<BankAccount> bankAccountList)
            {
                this.fullName = fullName;
                this.affiliation = affiliation;
                this.bankAccountList = bankAccountList;
            }

            // Core User Story 1
            public bool CreateCurrentAccount(BankAccount currentBankAccount)
            {
                if (!bankAccountList.Contains(currentBankAccount))
                {
                    bankAccountList.Add(currentBankAccount);
                    return true;
                }
                return false;
            }

            // Core User Story 2
            public bool CreateSavingsAccount(BankAccount savingsBankAccount)
            {
                if (!bankAccountList.Contains(savingsBankAccount))
                {
                    bankAccountList.Add(savingsBankAccount);
                    return true;
                }
                return false;
            }

            // Core User Story 4 - Deposit
            public virtual void DepositFunds(BankAccount bankAccount, double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be positive.");
                }
                var currentDate = DateTime.Now;
                var depositTransaction = new Transaction("Deposit", amount, currentDate, bankAccount.GetBalance + amount);
                bankAccount.TransactionList.Add(depositTransaction);
            }

            //Core User Story 4 - Withdrawal
            public virtual void WithdrawFunds(BankAccount bankAccount, double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be positive.");
                }
                var currentDate = DateTime.Now;
                var withdrawalTransaction = new Transaction("Withdrawal", amount, currentDate, bankAccount.GetBalance - amount);
                bankAccount.TransactionList.Add(withdrawalTransaction);
            }
        }

            public class BankStatement
        {
            // Core User Story 3
            public string GenerateBankStatement(BankAccount bankAccount)
            {
                // Handle case where no transactions are available
                if (bankAccount.TransactionList.Count == 0)
                {
                    return "No transactions available.";
                }

                var statementOutput = new StringBuilder();
                statementOutput.AppendLine("Date       || Deposit  || Withdrawal || Balance");

                // Sort transactions by date in descending order
                var sortedTransactions = bankAccount.TransactionList.OrderByDescending(t => t.Date);

                foreach (var transaction in sortedTransactions)
                {
                    // Correct alignment for Deposit and Withdrawal columns
                    var deposit = transaction.Type == "Deposit" ? transaction.Amount.ToString("F2", CultureInfo.InvariantCulture).PadRight(9) : "         ";
                    var withdrawal = transaction.Type == "Withdrawal" ? transaction.Amount.ToString("F2", CultureInfo.InvariantCulture).PadRight(11) : "           ";

                    // Output each transaction row
                    statementOutput.AppendLine(
                        $"{transaction.Date:dd/MM/yyyy} || {deposit}|| {withdrawal}|| {transaction.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
                }

                return statementOutput.ToString();
            }








        }

    }
}

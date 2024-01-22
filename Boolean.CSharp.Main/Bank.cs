using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank: UserAccount
    {
        Management management = new Management();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        private List<decimal> BalanceHistory { get; set; } = new List<decimal>();

        public void Deposit(string accountName, string accountType,  string branchName, decimal amount)
        {
            UserAccount account = UserAccount.GetAccount(accountName, accountType, branchName);
            if (account != null)
            {
                BalanceHistory.Add(amount);
                account.LastUpdateDate = DateTime.Now;
                Transaction depositTransaction = new Transaction(DateTime.Now, amount, "Deposit", account);
                Transactions.Add(depositTransaction);
                management.SendSMS("You have deposited " + amount);
                
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

        public void Withdraw(string accountName, string accountType, string branchName, decimal amount)
        {
            UserAccount account = GetAccount(accountName, accountType, branchName);
            if (account != null)
            {
                if (amount <= GetBalance(accountName, accountType, branchName))
                {
                    BalanceHistory.Add(-amount);
                    account.LastUpdateDate = DateTime.Now;
                    Transaction withdrawalTransaction = new Transaction(DateTime.Now, amount, "Withdrawal", account);
                    Transactions.Add(withdrawalTransaction);
                    management.SendSMS("You have withdrawn " + amount);
                }
                else if (amount > GetBalance(accountName, accountType, branchName))
                {
                    
                    if (management.OverDraftLimit(amount) == true)
                    {
                        BalanceHistory.Add(-amount);
                        account.LastUpdateDate = DateTime.Now;
                        Transaction withdrawalTransaction = new Transaction(DateTime.Now, amount, "Withdrawal", account);
                        Transactions.Add(withdrawalTransaction);
                        management.SendSMS("You have withdrawn " + amount);
                    }
                    else
                    {
                        management.SendSMS("You have exceeded your overdraft limit");
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

        public decimal GetBalance(string accountName, string accountType, string branchName)
        {
            UserAccount account = GetAccount(accountName, accountType, branchName);
            if (account != null)
            {
                int total = BalanceHistory.Sum(x => Convert.ToInt32(x));
                return total;
            }
            else
            {
                Console.WriteLine("Account not found");
                return 0;
            }
        }

        public void GenerateStatement(UserAccount account)
        {
            management.SendSMS("Your statement is ready");
         
            Console.WriteLine($"Statement for Account Name: {account.Name}, Account Type: {account.AccountType}, Branch Name: {account.BranchName}");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"Date: {transaction.Date}, Amount: {transaction.Amount}, Type: {transaction.TransactionType}");
            }
            Console.WriteLine($"Current Balance: {GetBalance(account.Name, account.AccountType, account.BranchName)}");
        }

    }
}

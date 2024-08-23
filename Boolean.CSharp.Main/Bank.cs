using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {

        private List<Account> _accounts = new List<Account>();

        private List<string> _users { get { return _accounts.Select(account => account.Owner).Distinct().ToList(); } }

        public int AddAccount(string user, BankTypes bankType)
        {

            if (bankType == BankTypes.Current)
            {
                Account account = new CurrentAccount(_accounts.Count(), bankType, user);
                _accounts.Add(account);

                return account.ID;
            }
            if (bankType == BankTypes.Saving)
            {
                Account account = new SavingsAccount(_accounts.Count(), bankType, user);
                _accounts.Add(account);
                return account.ID;
            }
            
            return -1;
        }

        //Added a secound one for extentions
        public int AddAccount(string user, BankTypes bankType, Branches branch)
        {
            if (bankType == BankTypes.Current)
            {
                Account account = new CurrentAccount(_accounts.Count(), bankType, user, branch);
                _accounts.Add(account);

                return account.ID;
            }
            if (bankType == BankTypes.Saving)
            {
                Account account = new SavingsAccount(_accounts.Count(), bankType, user, branch);
                _accounts.Add(account);
                return account.ID;
            }

            return -1;
        }

        public double Deposit(int ID, double amount)
        {
            if (_accounts.Where(account => account.ID == ID).Count() == 0)
            {
                return 0;
            }

            Account AcctoBeDeposited = GetAccount(ID);
            Transaction transaction = new Transaction(DateTime.Today.ToString("dd/MM/yyyy"), AcctoBeDeposited.Balance, amount, 0);
            AcctoBeDeposited.TransactionHistory.Add(transaction);

            AcctoBeDeposited.AddBalance(amount);
            return AcctoBeDeposited.CalculateBalance();
        }

        public double Withdraw(int ID, double amount)
        {
            if (_accounts.Where(account => account.ID == ID).Count() == 0)
            {
                return 0;
            }

            Account AccToBeWithdrawn = GetAccount(ID);
            Transaction transaction = new Transaction(DateTime.Today.ToString("dd/MM/yyyy"), AccToBeWithdrawn.Balance, 0, amount);
            

            bool succesfull = AccToBeWithdrawn.RemoveBalance(amount);

            if (succesfull)
            {
                AccToBeWithdrawn.TransactionHistory.Add(transaction);
            }    

            return AccToBeWithdrawn.CalculateBalance();
        }

        public string PrintBankStateMent(string user)
        {
            List<Account> accountsWithUser = FindAccountsUser(user).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"date\t\t|| credit\t|| debit\t|| balance\t");

            foreach (Account account in accountsWithUser)
            {
                sb.AppendLine(account.GenerateStatement());
            }

            return sb.ToString();
        }

        public Account GetAccount(int ID)
        {
            return _accounts.First(account => account.ID == ID);
        }
        public List<Account> FindAccountsUser(string user)
        {
            return _accounts.Where(account => account.Owner == user).ToList();
        }

        public double CalculateBalance(int ID)
        {
            return GetAccount(ID).CalculateBalance();
        }

        public int RequestOverdraft(int ID, double requestAmount)
        {
            Account account = GetAccount(ID);
            return account.AddOverDraftRequest(requestAmount);
        }

        public double ApproveOverdraftRequest(int accountID, int requestID, Roles role, RequestStatus status)
        {
            if (role!= Roles.Admin) {  return -1; }
               
            Account account = GetAccount(accountID);
            OverDraftRequest ODRequest = account.GetOverDraftRequest(requestID);

            ODRequest.Status = status;

            if (status == RequestStatus.Accepted)
            {
                account.Overdraft += ODRequest.Amount;
            }

            return account.Overdraft;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Entities;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Person;

namespace Boolean.CSharp.Main.Account
{
    public abstract class BankAccount
    {
        private List<BankTransaction> _transactions;
        private BankBranches _branch;
        private int _accountnumber;
        private string _accountname;
        private Customer _customer;

        public BankAccount(BankBranches branch, int accountnumber, string accountname, Customer customer)
        {
            this._transactions = new List<BankTransaction>();
            this._branch = branch;
            this._accountnumber = accountnumber;
            this._accountname = accountname;
            this._customer = customer;
        }

        public double MakeTransaction(BankTransaction tr)
        {
            if (tr.TransactionType == TransactionType.Withdrawal && tr.Credit > GetBalance()) 
            {
                Tuple<BankAccount, BankTransaction> tuple = new Tuple<BankAccount, BankTransaction> (this, tr);
                OverdraftRequests.overdraftRequests.Add(tuple);
                return GetBalance();
            } 
            this._transactions.Add(tr);
            SendTransaction(tr);
            return GetBalance();
        }

        public double ApprovedTransaction(BankTransaction transaction) 
        {
            this._transactions.Add(transaction);
            SendTransaction(transaction);
            return GetBalance();
        }

        public double GetBalance()
        {
           return this._transactions.Select(x => x.Debit).Sum() - this._transactions.Select(x => x.Credit).Sum();
        }

        public void PrintTransactionHistory()
        {
            double balance = 0;
            Console.WriteLine(string.Format("{0,-15} {1,-10} {2,-10} {3,-10}", "|| Date", "|| Credit", "|| Debit", "|| Balance"));
            foreach (BankTransaction transaction in this._transactions)
            {
                balance += transaction.Debit - transaction.Credit;
                Console.WriteLine(string.Format("{0,-15} {1,-10} {2,-10} {3,-10}", $"|| {transaction.Date.Day}/{transaction.Date.Month}/{transaction.Date.Year}", $"|| {transaction.Credit}", $"|| {transaction.Debit}", $"|| {balance}"));
            }
        }

        public void SendTransaction(BankTransaction tr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"New transaction on account: {this._accountname} : {this._accountnumber}");
            if(tr.TransactionType == TransactionType.Deposit)
            {
                sb.AppendLine($"{tr.Debit} was deposited to your account");
            }else
            {
                sb.AppendLine($"{tr.Credit} was credited from your account");
            }
            sb.AppendLine($"Current balance: {GetBalance()}");

            NotificationSender.SendTransactionConfirmation(sb.ToString(), this._customer.PhoneNumber);
        }

        public List<BankTransaction> Transactions { get => this._transactions; set => this._transactions = value; }
        public int Accountnumber { get => this._accountnumber; set => this._accountnumber = value; }
    }
}
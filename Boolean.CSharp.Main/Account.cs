using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _accountName;
        private List<BankTransaction> _transactions = [];
        private List<OverDraftRequest> _overDraftRequests = [];


        public void Deposit(BankTransaction transaction)
        {
            if (transaction.Type == TransactionType.Credit)
            {
                Transactions.Add(transaction);
                Transactions.Last().Balance = Transactions.Last().Balance + transaction.Amount;

            }
        }

        public void Withdraw(BankTransaction transaction)
        {
            if (transaction.Type == TransactionType.Debit)
            {
                
                if (transaction.Amount >= (GetBalance() + GetOverdraftBalance()))
                {
                    Transactions.Add(transaction);
                    Transactions.Last().Balance -= transaction.Amount;
                }
                
            }
        }
        public void PrintStatement()
        {
            Console.WriteLine($"Date    ||Credit    ||Debit     ||Balance");
            foreach (var item in Transactions)
            {
                if (item.Type == TransactionType.Credit)
                {
                    Console.WriteLine($"{item.TransactionDate.Date.ToString("dd/MM/yy")}||{item.Amount}     ||          ||{item.Balance}");
                };
                if (item.Type == TransactionType.Debit)
                {
                    Console.WriteLine($"{item.TransactionDate.Date.ToString("dd/MM/yy")}||          ||{item.Amount}     ||{item.Balance}");
                }
            }
        }

        public decimal GetBalance()
        {
            if(Transactions.Count() == 0)
            {
                return 0;
            }
            return Transactions.Last().Balance;
        }

        public string RequestOverDraft(decimal amount)
        {
            OverDraftRequest request = new OverDraftRequest(1, amount, this);
            OverDraftRequests.Add(request);

            return "Successfully applied for overdraft";
        }

        public void HandleOverDraftRequest(int id, OverDraftRequestStatus status)
        {
            OverDraftRequest request = OverDraftRequests.Find(x => x.Id == id);
            if (request == null)
            {
                throw new ArgumentException("Ayo this empty");
            }
            request.Status = status;
        }

        public decimal GetOverdraftBalance()
        {
            return OverDraftRequests.Where(x => x.Status == OverDraftRequestStatus.Approved).Sum(x => x.Amount);
        }

        public List<BankTransaction> Transactions { get { return _transactions; } set { _transactions = value; } }

        public List<OverDraftRequest> OverDraftRequests { get { return _overDraftRequests; } set { _overDraftRequests = value; } }
    }
}

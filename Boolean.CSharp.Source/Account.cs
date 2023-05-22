using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Boolean.CSharp.Source
{
    public abstract class Account
    {
        public List<Transaction> transactions = new List<Transaction> ();
        public List<OverdraftRequest> overdraft = new List<OverdraftRequest>();
        public Customer customer { get; set; }
        public string brancheName { get; set; }
        public Roles roles { get; set; }

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (Transaction t in transactions)
            {
                balance -= t.credit;
                balance += t.debit;
            }
            return balance;
        }
        public decimal OverdraftAmount()
        {
            OverdraftRequest overdraftRequest = overdraft.OrderByDescending(o => o.id).Where(o => o.status == true).FirstOrDefault();
            return overdraftRequest != null ? overdraftRequest.overdraftRequest : 0M ;
            //return 500M;
        }
        public void DepositMoney(decimal deposit)
        {
            Transaction transaction = new Transaction ();
            transaction.date = DateTime.Now;
            transaction.debit = deposit;
            transaction.newBalance = GetBalance() + deposit;
            transactions.Add (transaction);
        }

        public void WithdrawMoney(decimal withdraw)
        {
            Transaction transaction = new Transaction();
            // if balance + overdraftAmount
            
            //if (GetBalance() + OverdraftAmount() > withdraw)
            if ((GetBalance() - withdraw) + Math.Abs(OverdraftAmount()) >= 0)
                { 
            transaction.date = DateTime.Now;
            transaction.credit = withdraw;
            transaction.newBalance = GetBalance() - withdraw;
            transactions.Add(transaction);
            }
            else
            {
                OverdraftRequest request = new OverdraftRequest ();
                request.overdraftRequest = GetBalance() - withdraw;
                request.id = overdraft.Count == 0 ? 1: overdraft.Max(o => o.id)+1;
                overdraft.Add(request);
            }
        }     

        public void BankStatement()
        {
           
             Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (Transaction transaction in transactions.OrderByDescending(t => t.date)) 
            {
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                            transaction.date.ToShortDateString(),
                            transaction.credit == 0 ? "":transaction.credit,
                            transaction.debit == 0 ? "" : transaction.debit,
                            transaction.newBalance);
              
            }
            ;
        }
        public bool OverdraftAcceptance(int id)
        {
           // get the overdraft Request 
           // manager
           // change status
           var req = overdraft.Where(o => o.id == id).FirstOrDefault();
            if (req != null) { 
                if(roles == Roles.manager)
                {
                    req.status=true;
                    return true;
                }
            }
            return false;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main
{
    public class Customer    {
        private int _id; 
        private string _name;
        private List<Account> _accounts;     
        public Customer(int id, string name) { 
        
            _id = id;
            _name = name;
        }

        public void AddAccount(Account account)
        {
            _accounts = new List<Account>();
            _accounts.Add(account);
        }

        public void DisplayTransactions(Account account)
        {
            Console.WriteLine("{0,-12} || {1,-15} || {2,-12} || {3,-12}", "Date", "Credit", "Debit", "Balance");
            Console.WriteLine("{0,-12} || {1,-15} || {2,-12} || {3,-12}", "------------", "---------------", "------------", "------------");
            account.Transactions.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));
            account.Transactions.Reverse();
            account.Transactions.ForEach(t =>
            {
                if (t.TransactionType == TransactionType.Credit)
                {
                    Console.WriteLine("{0,-12} || {1,-15} || {2,-12} || {3,-12}", $"{t.DateTime.Day}/{t.DateTime.Month}/{t.DateTime.Year}", t.Amount, "", t.Balance);
                }
                else
                {
                    Console.WriteLine("{0,-12} || {1,-15} || {2,-12} || {3,-12}", $"{t.DateTime.Day}/{t.DateTime.Month}/{t.DateTime.Year}", "", t.Amount, t.Balance);
                }
            });
        }
      

        public List<Account> Accounts { get { return _accounts;  } }
        public string Name { get { return _name;} }
        
    
    }
}

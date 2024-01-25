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
        private string _telephone;
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

        // Should be in account...

        public string GetTransactionDetails(Account account)
        {
            StringBuilder transactionDetails = new StringBuilder();

            transactionDetails.AppendLine($"{"Date",-12} || {"Credit",-15} || {"Debit",-12} || {"Balance",-12}");
            transactionDetails.AppendLine($"{"------------",-12} || {"---------------",-15} || {"------------",-12} || {"------------",-12}");

            account.Transactions.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));
            account.Transactions.Reverse();

            account.Transactions.ForEach(t =>
            {
                string date = t.DateTime.ToString("dd/MM/yyyy");
                string credit = (t.TransactionType == TransactionType.Credit) ? t.Amount.ToString() : "";
                string debit = (t.TransactionType == TransactionType.Debit) ? t.Amount.ToString() : "";

                transactionDetails.AppendLine($"{date,-12} || {credit,-15} || {debit,-12} || {t.Balance,-12}");
            });

            return transactionDetails.ToString();
        }

        public void DisplayTransactions(string statement)
        {
            Console.WriteLine(statement);
        }

        public List<Account> Accounts { get { return _accounts;  } }
        public string Name { get { return _name;} }
        
        public string Telephone { get { return _telephone;} set { _telephone = value; } }
    
    }
}

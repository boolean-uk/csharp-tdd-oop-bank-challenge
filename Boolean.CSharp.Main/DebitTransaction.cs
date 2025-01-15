using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main
{
    public class DebitTransaction : ITransaction
    {
        public decimal transactionAmount { get; set; }
        public DateTime transactionDate { get; set; }
        public string type { get; set; } = "Debit";
        public decimal balance {  get; set; }
        

        public DebitTransaction(decimal _transactionAmount)
        {
            this.transactionAmount = _transactionAmount;
            this.transactionDate = DateTime.Now;
        }
        public void PrintTransactions()
        {
            string formattedDate = transactionDate.ToString("dd.MM.yyyy");
            Console.WriteLine($"{formattedDate,-12}|| {"",-8} || {transactionAmount,-8:F2} || {balance:F2}");
            
        }

        public string PrintTransactionsString()
        {
            string formattedDate = transactionDate.ToString("dd.MM.yyyy");
            return $"{formattedDate,-12}|| {transactionAmount,-8:F2} || {"",-8} || {balance:F2}";
            
        }



    }
}

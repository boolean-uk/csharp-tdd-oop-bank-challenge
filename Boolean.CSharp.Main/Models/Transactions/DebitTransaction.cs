using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models.Transactions
{
    public class DebitTransaction : ITransaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public DebitTransaction(decimal amount, decimal balance) 
        {
            Amount = amount;
            Date = DateTime.Now;
            Balance = balance + amount;
        }
        public void printTransaction()
        {
            Console.WriteLine(transactionString());
        }
        public string transactionString()
        {
            // Format each transaction with appropriate column widths
            string credit = "";
            string debit = Amount.ToString("F2");
            string balanceFormatted = Balance.ToString("F2");

            // Return the formatted string for the transaction
            return String.Format("{0,-12} || {1,-8} || {2,-8} || {3,-10}", Date.ToString("dd/MM/yyyy"), credit, debit, balanceFormatted);
        }

    }
}

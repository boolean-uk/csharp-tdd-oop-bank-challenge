using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models.Transactions
{
    public class CreditTransaction : ITransaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public CreditTransaction(decimal amount, decimal balance)
        {
            Amount = amount;
            Date = DateTime.Now;
            Balance = balance - amount;
        }

        public void printTransaction()
        {
            Console.WriteLine(transactionString());
        }
        //I Might have gotten some help on the formating
        public string transactionString()
        {
            string credit = $"-${Amount.ToString("F2")}";
            string debit = "";
            string balanceFormatted = Balance.ToString("F2");

            return String.Format("{0,-12} || {1,-8} || {2,-8} || {3,-10}", Date.ToString("dd/MM/yyyy"), credit, debit, balanceFormatted);
        }

    }
}
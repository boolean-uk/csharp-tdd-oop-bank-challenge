using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interface
{
    public interface ITransaction
    {
        decimal transactionAmount { get; set; }
        DateTime transactionDate { get; set; }

        string type { get; set; }
        decimal balance { get; set; }



        public void PrintTransactions()
        {
            string formattedDate = transactionDate.ToString("dd.MM.yyyy");

            if (type == "Credit")
            {
                
                Console.WriteLine($"{formattedDate,-12}|| {transactionAmount,-8:F2} || {"",-8} || {balance:F2}");
            }
            else
            {
                
                Console.WriteLine($"{formattedDate,-12}|| {"",-8} || {transactionAmount, -8:F2} || {balance:F2}");
            }
        }


    }


}


using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class MainMenu
    {
        public List<BankTransaction> TransactionHistory = new List<BankTransaction>();

        public void Write_Statement()
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}","Date", "Credit", "Debit", "Balance");
            foreach (BankTransaction transaction in TransactionHistory)
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}",
                        transaction.Date,
                        transaction.Transaction_type == Enums.Transaction.Withdraw ? transaction.Amount : 0,
                        transaction.Transaction_type == Enums.Transaction.Deposit ? transaction.Amount : 0,
                        transaction.NewBalance);
            };
        }

        // As a manager
        public void Qualify_Overdraft(CurrentAccount account)
        {
            if(account.overdraft_amount <= 2000)
            {
                account.Overdraft = Overdraft.Approved;
            }
            else
            {
                account.Overdraft = Overdraft.Rejected;
            }
        }

    }
}

using Boolean.CSharp.Main.enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class TransactionManager : IBankTransaction
    {
        private List<Tuple<DateTime, decimal, TransactionType, decimal>> _history = new List<Tuple<DateTime, decimal, TransactionType, decimal>>();

        public decimal CalculateAccountBalance() 
        {
            decimal res = 0;
            foreach (Tuple<DateTime, decimal, TransactionType, decimal> tuple in _history)
            {
                if (tuple.Item3 == TransactionType.Withdraw)
                {
                    res -= tuple.Item2;
                } 
                else if (tuple.Item3 == TransactionType.Deposit) 
                {
                    res += tuple.Item2;
                }
            }
            return res;
        }

        /// <summary>
        /// Add an item to the transaction history marked as a deposit
        /// </summary>
        /// <param name="amount">The amount of money to be deposit into the account</param>
        /// <returns>A boolean if the transaction was succesfully recorded</returns>
        public bool AddDepositTransaction(decimal amount)
        {
            int val1 = _history.Count;
            Tuple<DateTime, decimal, TransactionType, decimal>? lastEntry = _history.OrderBy(t => t.Item1).LastOrDefault();
            if (lastEntry == null)
            {
                _history.Add(new Tuple<DateTime, decimal, TransactionType, decimal>(DateTime.Now, amount, TransactionType.Deposit, amount));
            }
            else 
            {
                _history.Add(new Tuple<DateTime, decimal, TransactionType, decimal>(DateTime.Now, amount, TransactionType.Deposit, lastEntry.Item4 + amount));
            }
            int val2 = _history.Count;
            return val2 > val1;
        }

        /// <summary>
        /// Add an item to the transaction history marked as a withdrawal
        /// </summary>
        /// <param name="amount">The amount of money to be withdrawn from the account</param>
        /// <returns>A boolean if the transaction was succesfully recorded</returns>
        public bool AddWithdrawTransaction(decimal amount)
        {
            int val1 = _history.Count;
            Tuple<DateTime, decimal, TransactionType, decimal>? lastEntry = _history.OrderBy(t => t.Item1).LastOrDefault();
            if (lastEntry == null)
            {
                _history.Add(new Tuple<DateTime, decimal, TransactionType, decimal>(DateTime.Now, amount, TransactionType.Withdraw, amount));
            }
            else
            {
                _history.Add(new Tuple<DateTime, decimal, TransactionType, decimal>(DateTime.Now, amount, TransactionType.Withdraw, lastEntry.Item4 - amount));
            }
            int val2 = _history.Count;
            return val2 > val1;
        }

        /// <summary>
        /// Print all transactions that occured between the provided start time and end time
        /// </summary>
        /// <param name="start"> The minimum date for transaction to be printed </param>
        /// <param name="end"> The maximum date for transaction to be printed </param>
        public void PrintTransactions(DateTime start, DateTime end)
        {
            int _padLeft = 10;
            int _padMiddleLeft = 8;
            int _padMiddleRight = 8;
            int _padRight = 8;
            CultureInfo culture = new CultureInfo("en-GB");
            decimal creditValue;
            decimal debitValue;

            // Gather the items matching the start/end intervall and order by descending based on DateTime
            List<Tuple<DateTime, decimal, TransactionType, decimal>> historySegment = _history.Where(t => (start < t.Item1) && (t.Item1 < end)).OrderByDescending(t => t.Item1).ToList();
            
            Console.Write($"date".PadRight(_padLeft) + " || " + $"credit".PadRight(_padMiddleLeft) + " || ");
            Console.Write($"debit".PadRight(_padMiddleRight) + " || " + $"balance".PadRight(_padRight) +"\n");
            foreach (Tuple<DateTime, decimal, TransactionType, decimal> tuple in historySegment) 
            {
                if (tuple.Item3 == TransactionType.Deposit)
                {
                    creditValue = tuple.Item2;
                    debitValue = 0m;
                    Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy", culture)}".PadRight(_padLeft) + " || " + $"{creditValue:F2}".PadRight(_padMiddleLeft) + " || " +
                        $"".PadRight(_padMiddleRight) + " || " + $"{tuple.Item4:F2}".PadRight(_padRight));
                }
                else if (tuple.Item3 == TransactionType.Withdraw)
                {
                    creditValue = 0m;
                    debitValue = tuple.Item2;
                    Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy", culture)}".PadRight(_padLeft) + " || " + $"".PadRight(_padMiddleLeft) + " || " +
                    $"{debitValue:F2}".PadRight(_padMiddleRight) + " || " + $"{tuple.Item4:F2}".PadRight(_padRight));
                }
                else 
                {
                    creditValue = 0m;
                    debitValue = 0m;
                    Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy", culture)}".PadRight(_padLeft) + " || " + $"".PadRight(_padMiddleLeft) + " || " +
                        $"".PadRight(_padMiddleRight) + " || " + $"{tuple.Item4:F2}".PadRight(_padRight));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _date;
        private decimal _amount;
        private decimal _credit;
        private decimal _debit;

        public Transaction(DateTime date, decimal amount, decimal credit, decimal debit)
        {
            _date = DateTime.Now;
            _amount = amount;
            _credit = credit;
            _debit = debit;
        }

        public string GetTransaction()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("date       || credit  || debit  || balance");

            sb.AppendFormat("{0:dd/MM/yyyy}", _date).Append(" || ");

            if (_credit > 0)
            {
                sb.AppendFormat("{0,8:0.00}", _credit).Append(" || ");
            }
            else
            {
                sb.Append("        || ");
            }

            if (_debit > 0)
            {
                sb.AppendFormat("{0,8:0.00}", _debit).Append(" || ");
            }
            else
            {
                sb.Append("        || ");
            }

            sb.AppendFormat("{0,8:0.00}", _amount);

            return sb.ToString();
        }

        public void PrintTransaction()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("date       || credit  || debit  || balance");

            sb.AppendFormat("{0:dd/MM/yyyy}", _date).Append(" || ");

            if (_credit > 0)
            {
                sb.AppendFormat("{0,8:0.00}", _credit).Append(" || ");
            }
            else
            {
                sb.Append("        || ");
            }

            if (_debit > 0)
            {
                sb.AppendFormat("{0,8:0.00}", _debit).Append(" || ");
            }
            else
            {
                sb.Append("        || ");
            }

            sb.AppendFormat("{0,8:0.00}", _amount);

            Console.WriteLine(sb.ToString());
        }

    }
}

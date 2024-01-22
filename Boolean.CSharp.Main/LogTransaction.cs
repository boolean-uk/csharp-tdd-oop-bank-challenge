using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class LogTransaction
    {
        private List<string> _logs = new List<string>();
        public string AddLog(double change, float newBalance)
        {
            string formattedString = Math.Abs(change).ToString("0.00");
            while (formattedString.Length < 7)
                formattedString = " " + formattedString;
            string formattedNewBalance = newBalance.ToString("0.00");
            while (formattedNewBalance.Length < 7)
                formattedNewBalance = " " + formattedNewBalance;
            string result;
            string date = DateTime.Now.ToString("d");

            if (change > 0)
            {
                result = $"{date} || {formattedString} ||         || {formattedNewBalance}";
            }
            else if (change < 0)
            {
                result = $"{date} ||         || {formattedString} || {formattedNewBalance}";

            }
            else result = $"{date} ||         ||         || {formattedNewBalance}";
            _logs.Add(result);
            return result;
        }
        public void Print()
        {
            Console.WriteLine("Date       || Credit  || Debit   || Balance ");
            foreach (string log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}

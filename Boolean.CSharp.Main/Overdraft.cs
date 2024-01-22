using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    // Probably make some parent with this and Transaction class
    public class Overdraft
    {
        private string _id;
        private DateTime _date;
        private decimal _amount;

        public string Id { get { return _id; } }
        public DateTime Date { get { return _date; } }
        public decimal Amount { get { return _amount; } }

        public Overdraft(decimal amount)
        {
            //generate id 
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            _id = new string(Enumerable.Range(1, 10).Select(_ => chars[random.Next(chars.Length)]).ToArray());
            _date = DateTime.Now;
            _amount = amount;

        }
    }
}

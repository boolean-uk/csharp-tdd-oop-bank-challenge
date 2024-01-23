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
        private Guid _id;
        private DateTime _date;
        private decimal _amount;

        public Guid Id { get { return _id; } }
        public DateTime Date { get { return _date; } }
        public decimal Amount { get { return _amount; } }

        public Overdraft(decimal amount)
        {
            _id = Guid.NewGuid();
            _date = DateTime.Now;
            _amount = amount;

        }
    }
}

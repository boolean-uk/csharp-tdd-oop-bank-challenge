using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Overdraft
{
    public class OverdraftObj
    {
        private string _accountName;
        private double _amount;
        private DateTime _date;
        public OverdraftStatus OverdraftStatus {  get; set; }
        public OverdraftObj(string name, double amount) 
        {
            _accountName = name;
            _amount = amount;
            _date = DateTime.Now;
            OverdraftStatus = OverdraftStatus.Pending;
        }
        public string Name { get { return _accountName; } }
        public double Amount { get { return _amount; } }
        public DateTime DateTime { get { return _date;} }

    }
}

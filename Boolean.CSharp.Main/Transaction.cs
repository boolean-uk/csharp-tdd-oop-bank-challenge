using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction : IBankTransaction
    {
        private DateTime _date;
        private string _type;
        private int _amount;
        private string _status;
        private int _newBalance;

        public Transaction(DateTime date, string type, int amount, string status, int newBalance)
        {
            this._date = date;
            this._type = type;
            this._amount = amount;
            this._status = status;
            this._newBalance = newBalance;
        }
        
        public DateTime Date { get { return _date; } set { _date = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public int Amount { get { return _amount; } set { _amount = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public int NewBalance { get {  return _newBalance; } set {  _newBalance = value; } }
    }
}

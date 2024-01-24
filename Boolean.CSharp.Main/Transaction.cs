using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    /// <summary>
    /// Each time the user want to perform a transaction, this class will be call.
    /// The amount, type and mark shall be assigned.
    /// </summary>
    public class Transaction
    {
        
        double _amount;
        string _mark;
        TransactionType _type;
        DateTime _transactionDate = DateTime.Now;
        bool _transactionStatus = false;
        double _newBalance;

        public double Amount { get { return _amount; } set {  _amount = value; } }
        public string Mark { get { return _mark;} set { _mark = value; } }  
        public TransactionType Type { get { return _type;} set { _type = value; } } 
        public DateTime DateInfo { get { return _transactionDate; } }
        public bool TransectionStatus { get { return _transactionStatus; } set { _transactionStatus = value; } } 
        public double NewBalance { get { return _newBalance; } set { _newBalance = value; } }

    }
}

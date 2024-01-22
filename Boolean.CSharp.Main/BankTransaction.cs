using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boolean.CSharp.Main
{
    public class BankTransaction
    {
        private int _id = 0;
        private string _date;
        private string _transactionType;
        private decimal _newAmount;
        private string[] _transactionsDetails;
        private decimal _dAmount = 0;
        public BankTransaction(int id,decimal amount, decimal oldAmount)
        {
            _id = id;
            _date = DateTime.Now.Date.ToString().Substring(0,10);
            if(amount >= 0)
            {
                _transactionType = "credit";
            }else{
                _transactionType = "debit";
            }

            _newAmount = oldAmount + amount;
            _dAmount = Math.Abs(amount);
            _transactionsDetails = new string[5];

        }
      
        public string[] GetTransactionString()
        {
            _transactionsDetails = [ _id.ToString(),_date.ToString(),_transactionType, _dAmount.ToString(),_newAmount.ToString() ];
           
            return _transactionsDetails;
        }
        
    }
}

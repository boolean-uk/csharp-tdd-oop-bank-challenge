using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boolean.CSharp.Main
{
    public class BankTransaction
    {
        private int _id = 0;
        private DateTime _date;
        private string _transactionType;
        private decimal _newBalance;
        private Transaction _transaction;
        private decimal _dAmount = 0;
        private string _transactionStatus;
        public BankTransaction(int id, decimal amount, decimal oldAmount)
        {
            _id = id;
            _date = DateTime.Now.Date;
            if (amount >= 0)
            {
                _transactionType = Type.credit.ToString();
            } else {
                _transactionType = Type.debit.ToString();
            }
            _newBalance = oldAmount + amount;
           
            _dAmount = Math.Abs(amount);
            if(_dAmount > oldAmount)
            {
                _transactionStatus = Status.pending.ToString();
            }else if(oldAmount>= _dAmount) {
                _transactionStatus = Status.approved.ToString();
            }
            else { _transactionStatus = Status.rejected.ToString(); }
            
            _transaction =  new Transaction() { TransactionId = _id, TransactionType = _transactionType, TransactionAmount = _dAmount, Date = _date, Balance = _newBalance, TransactionStatus = _transactionStatus };
            
        }

        public Transaction GetTransaction()
        {
            return _transaction;
        }
        public int Id {  get { return _id; } }
    }

    public class Transaction
    {
        public int TransactionId{ get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionAmount{ get; set; }
        public DateTime Date{ get; set; }
        public decimal Balance { get; set; }
        public string TransactionStatus {  get; set; }
        

     

    }
  


}

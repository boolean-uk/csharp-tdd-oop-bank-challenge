using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;

namespace Boolean.CSharp.Main
{
    public struct Transaction
    {
        private Guid? _toAccountNumber;
        private Guid? _fromAccountNumber;
        private float _amount;
        private DateTime _timeOfTransaction = DateTime.Now;

        public Transaction(Guid? fromAccount, Guid? toAccount, float amount) {
            _fromAccountNumber = fromAccount;
            _toAccountNumber = toAccount;
            _amount = amount;
        }

        public Guid? ToAccountNumber { get { return _toAccountNumber; } }
        public Guid? FromAccountNumber { get { return _fromAccountNumber; } }
        public float Amount {  get { return _amount; } }
        public DateTime TimeOfTransaction { get { return _timeOfTransaction; } }
    }
}

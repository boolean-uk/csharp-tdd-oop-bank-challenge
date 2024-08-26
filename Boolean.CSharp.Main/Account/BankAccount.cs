using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Entities;
using Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main.Account
{
    public abstract class BankAccount
    {
        private List<BankTransaction> _transactions;
        private BankBranches _branch;
        private int _accountnumber;

        public BankAccount(BankBranches branch, int accountnumber)
        {
            this._transactions = new List<BankTransaction>();
            this._branch = branch;
            this._accountnumber = accountnumber;
        }


        public double MakeTransaction(BankTransaction tr)
        {   
            throw new NotImplementedException();
        }

        public double ApprovedTransaction(BankTransaction transaction) 
        { 
            throw new NotImplementedException(); 
        }

        public double GetBalance()
        {
            throw new NotImplementedException();
        }

        public List<BankTransaction> Transactions { get => this._transactions; set => this._transactions = value; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    
    public interface Iaccount
    {
        public List<Transaction> GetTransactions();
        public bool AddTransaction(float f);
        public float GetBalance();
        String GenerateTransationsHistory();
    }
    public class Account : Iaccount
    {
        private List<Transaction> transactions;
        public  List<Transaction> Transactions { get { return transactions; } }
    
        public Account() {
            
        }



        public bool AddTransaction(float f)
        {
            throw new NotImplementedException();
        }

        public float GetBalance()
        {
            throw new NotImplementedException();
        }
         public List<Transaction> GetTransactions() { throw new NotImplementedException(); }
        public string GenerateTransationsHistory()
        {
            throw new NotImplementedException();
        }


    }

    public class SavingsAccount : Account
    {
        public SavingsAccount() { }
    }
        
        public class CurrentAccount : Account
    {
        public CurrentAccount() { }
    }


    public readonly struct Transaction {
        readonly DateTime CreationDate;
        readonly float Amount;
        public Transaction(DateTime creationDate, float amount)
        {
            CreationDate = creationDate;
            Amount = amount;
        }
    }



}

using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class CurrentAccount : AccountAbstract
    {
        public bool overdraft = false;
        public CurrentAccount(string name) : base(name)
        {
            
        }
        
        public bool SetOverdraft(bool b)
        {
            return this.overdraft = b;
        }

        public override void Withdraw(double amount)
        {
            
            if (!this.overdraft && amount > this.Balance)
            {
                return; 
            }

            Transaction transaction = new Transaction(DateTime.Now.ToString("dd/MM/yyyy"), 0, amount, Balance);
            Transactions.Add(transaction);
            this.Balance = Transactions.Sum(t => t.credit - t.debit);
        }

    }
}

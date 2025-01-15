using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class SavingAccount : AccountAbstract
    {
        public SavingAccount(string name) : base(name)
        {

        }
        public override void Withdraw(double amount)
        {
            if (amount > this.Balance)
            {
                return;
            }
            Transaction transaction = new Transaction(DateTime.Now.ToString("dd/MM/yyyy"), 0, amount, Balance);
            Transactions.Add(transaction);
            this.Balance -= amount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.BankAndAccounts
{
    public class Saving : Account
    {
        public Saving(ICustomer customer, IBranch branch) : base(customer, branch, false) { }

        public override void Deposit(decimal amount)
        {
            string depositMessage = "\n";
            //Date of transaction
            depositMessage += DateTime.Now.ToString("dd/MM/yyyy") + "\t||";
            //Deposit
            depositMessage += amount.ToString() + "\t||";
            //Empty
            depositMessage += "\t\t||";
            //New Balance
            depositMessage += (Balance() + amount).ToString();
            this.transactionHistory.Add(depositMessage);
        }

        public override bool Withdraw(decimal amount)
        {
            //Get the old balance and check if we can withdraw that amount
            decimal oldBalance = Balance();
            if (oldBalance >= amount && amount <= 500) //Maximum allowed withdraw is 500 on a savings account | CANNOT OVERDRAFT
            {
                string depositMessage = "\n";
                //Date of transaction
                depositMessage += DateTime.Now.ToString("dd/MM/yyyy") + "\t||";
                //Empty
                depositMessage += "\t\t||";
                //Withdraw
                depositMessage += amount.ToString() + "\t||";
                //New Balance
                depositMessage += (oldBalance - amount).ToString();
                this.transactionHistory.Add(depositMessage);
                return true;
            }
            return false;
        }
    }
}

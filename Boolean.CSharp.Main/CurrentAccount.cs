using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public override void Withdraw(double amount, bool overdraftApproval)
        {
            if (base.Balance < amount && !overdraftApproval) 
            {

                throw new ArgumentException($"Insuficcinet funds! Balance: {base.Balance}\n Sent overdraft request to manager!");
            }
            else {
                base.Balance -= amount;

                DateTime date = DateTime.Today;
                Transaction withrawal = new Transaction(date, -1 * amount, Balance);
                Transactions.Add(withrawal);
            }
        }

        public CurrentAccount(string accountnumber, string name, Roles ownerRrole ) : base(accountnumber, name, ownerRrole) { }


    }
}

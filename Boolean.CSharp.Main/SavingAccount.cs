using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public class SavingAccount : Account
    {
        public SavingAccount(Branch branch) : base(branch) { }

        public void withdraw(double amount, DateTime date)
        {
            if (amount >= Balance())
            {
                Console.WriteLine("Withdrawing from savings account");
                base.withdraw(amount, date);
            }
            else
            {
                Console.WriteLine("Not enouch money in account");
            }
        }
        public void setOverDrawAmount(double overDrawAmount)
        {
            Console.WriteLine("Can not overdraw a savings account");
        }
    }
}

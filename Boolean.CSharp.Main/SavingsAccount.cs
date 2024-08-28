
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(decimal number):base(number) 
        {
           
        }

        public decimal CalculateBalance()
        {
            throw new NotImplementedException();
        }

        public void ManagerAccess(string v)
        {
            throw new NotImplementedException();
        }
    }
}
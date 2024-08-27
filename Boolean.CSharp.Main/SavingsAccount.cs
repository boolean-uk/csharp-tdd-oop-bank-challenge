
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(decimal number):base(number) 
        {
           
        }

        public void Withdraw(int v)
        {
            throw new NotImplementedException();
        }
    }
}
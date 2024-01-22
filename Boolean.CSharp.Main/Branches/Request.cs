using Boolean.CSharp.Main.Accounts;

namespace Boolean.CSharp.Main.Branches
{
    public class Request(string reason, double amount, IAccount account)
    {
        public string Reason => reason;
        public double Amount => amount;
        public IAccount Account => account;
    }
}
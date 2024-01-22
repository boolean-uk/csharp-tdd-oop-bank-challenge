namespace Boolean.CSharp.Main.Branches
{
    public class Request(string reason, double amount)
    {
        public string Reason => reason;
        public double Amount => amount;
    }
}
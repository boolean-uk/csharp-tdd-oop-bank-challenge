namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public float OverdraftLimit { get; set; }
        public CurrentAccount(int id , Branch branch) : base(id , branch) { }
    }
}

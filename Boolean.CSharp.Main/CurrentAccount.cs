namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account 
    {
        public CurrentAccount(int branch, string phonenr,
            ISMSProvider smsprovider, IStatement statementbuilder) :
            base(branch, phonenr, statementbuilder, smsprovider)
        {
        }
        public CurrentAccount(int branch, string phonenr) : base(branch, phonenr) { }
    }
}

namespace Boolean.CSharp.Main
{
    public interface ISMSProvider
    {
        public abstract void SendSMS(string phonenr, string statement);
    }
}

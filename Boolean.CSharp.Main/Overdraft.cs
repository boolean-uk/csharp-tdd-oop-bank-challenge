namespace Boolean.CSharp.Main
{
    public class Overdraft
    {
        private decimal _amount;

        public Overdraft(decimal amount)
        {
            _amount = amount;
        }

        public decimal GetOverdraftAmount()
        {
            return _amount;
        }
    }
}

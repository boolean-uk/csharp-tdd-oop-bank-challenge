using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class GeneralAccount : IAccount
    {

        private string _ID;
        List<Transaction> _transactions = new List<Transaction>();

        public GeneralAccount()
        {
            _ID = Guid.NewGuid().ToString();
        }

        public float getBalance()
        {
            return 0;
        }
    }
}

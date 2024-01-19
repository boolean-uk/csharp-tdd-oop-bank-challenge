using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public float getBalance();

        public bool MakeTransaction(Transaction transaction);

        public void ListBankStatement();


    }
}

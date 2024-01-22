using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    abstract public class ABankAccount
    {
        List<BankStatement> _transactions;
        double _creditDebit;
        bool valid;
        public enum eType
        {
            Withdraw,
            Deposit
        }
        eType _type;

        public double Transaction {  get;}

        public ABankAccount() 
        {
            
        }
    }
}

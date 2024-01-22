using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.Objects
{
    public class BankStatement
    {
        private int _id;
        private List<ITransaction> _transactions = new List<ITransaction>();

        public BankStatement()
        {
            _id += 1;
        }
        public int Id { get { return _id; } set { _id = value; } }
        public List<ITransaction> Transactions { get { return _transactions; } set { _transactions = value; } }

    }
}

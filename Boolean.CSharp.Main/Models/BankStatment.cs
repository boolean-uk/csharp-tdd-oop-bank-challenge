using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class BankStatement
    {
        public int AccountNumber { get; set; }

        public BankStatement(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public string GetStatment()
        {
            throw new NotImplementedException();
        }
    }
}

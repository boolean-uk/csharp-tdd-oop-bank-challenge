using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Bank
    {
        private List<Engineer> engineerList;
        private List<BankAccount> bankAccountList;

        public Bank()
        {
            this.engineerList = new List<Engineer>();
            this.bankAccountList = new List<BankAccount>();
        }

    }
}

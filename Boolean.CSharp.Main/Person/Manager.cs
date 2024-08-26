using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Person
{
    public class Manager
    {
        private List<BankTransaction> _bankTransactions;

        public Manager()
        {

        }

        public List<Tuple<BankAccount, BankTransaction>> GetOverdraftRequests()
        {
            return OverdraftRequests.overdraftRequests;
        }

        public void ApproveRequest(Tuple<BankAccount, BankTransaction> b)
        {
            throw new NotImplementedException();
        }
    }
}

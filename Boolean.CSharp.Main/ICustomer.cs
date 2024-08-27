using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface ICustomer
    {
        public Account createCurrentAccount(Customer customer, string branch);

        public Account createSavingsAccount(Customer customer, string branch);

        public void requestsOverDraft(Account ca);
    }
}

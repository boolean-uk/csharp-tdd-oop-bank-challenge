using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<Account> accounts = new List<Account>();
        public int UniqueId;
        public Bank() {
            accounts = new List<Account>();
            UniqueId = 0;
        }

        public int GenerateAccountId() { 
            
            UniqueId++;
            return UniqueId+100; 
        }
        public int GenerateTransactionId()
        {

            UniqueId++;

            return UniqueId+1000;
        }
        public int GenerateUserId()
        {

            UniqueId++;

            return UniqueId;
        }
    }
}

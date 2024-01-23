using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class HeadQuarters
    {
        private List<Account> AllAccounts = new List<Account>();
        public int UniqueId;
        private List<ICustomer> AllUsers;
        public List<Branch> AllBranches;
       
        public HeadQuarters() {
            UniqueId = 0;
            AllUsers = new List<ICustomer>();
            AllBranches = new List<Branch>();
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

        public bool AddNewLocation(Enum location)
        {
            if(Enum.IsDefined(typeof(Location), location)) {
                Branch branch = new Branch(location);
                AllBranches.Add(branch);
                
                return true;
           }

            return false;
        }

    }
}

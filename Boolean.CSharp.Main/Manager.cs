using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager
    {
        private int _id;
        private string _name;
        private List<OverdraftRequest> _overdraftRequests;

        public Manager(int id, string name) 
        {
            throw new NotImplementedException();
        }

        public int Id { get => _id; }
        public string Name { get => _name; }
        public List<OverdraftRequest> OverdraftRequests { get => _overdraftRequests; }

        public void UpdateOverdraftRequests(List<OverdraftRequest> overdraftRequests)
        {
            throw new NotImplementedException();
        }

        public void ApproveAllOverdraftRequests()
        {
            throw new NotImplementedException();
        }

        public void ApproveOverdraftRequestsAmount(double amount)
        {
            throw new NotImplementedException();
        }

        public void ApproveOverdraftRequestsId(int id)
        {
            throw new NotImplementedException();
        }

        public void RejectAllOverdraftRequests()
        {
            throw new NotImplementedException();
        }

        public void RejectOverdraftRequestsAmount(double amount)
        {
            throw new NotImplementedException();
        }

        public void RejectOverdraftRequestsId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

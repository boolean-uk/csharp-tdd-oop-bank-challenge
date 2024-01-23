using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boolean.CSharp.Main
{
    public class Manager(string name)
    {
        public string Name { get; set; } = name;
        public List<OverdraftRequest> OverdraftRequests { get; set; } = new List<OverdraftRequest>();

        public void AddOverdraftRequest(OverdraftRequest overdraft)
        {
            OverdraftRequests.Add(overdraft);
        }

        private List<OverdraftRequest> ApproveRequests(IEnumerable<OverdraftRequest> requests)
        {
            List<OverdraftRequest> newlyApproved = new List<OverdraftRequest>();
            foreach (var request in requests)
            {
                request.Status = OverdraftStatus.Approved;
                newlyApproved.Add(request);
            }
            return newlyApproved;
        }

        public List<OverdraftRequest> ApproveAllOverdraftRequests()
        {
            return ApproveRequests(OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending));
        }

        public List<OverdraftRequest> ApproveOverdraftRequestsAmount(double amount)
        {
            var pendingRequests = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            return ApproveRequests(pendingRequests.Where(o => o.Amount <= amount));
        }

        public List<OverdraftRequest> ApproveOverdraftRequestsId(int id)
        {
            var pendingRequests = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            return ApproveRequests(pendingRequests.Where(o => o.Id == id));
        }

        private void RejectRequests(IEnumerable<OverdraftRequest> requests)
        {
            foreach (var request in requests)
            {
                request.Status = OverdraftStatus.Rejected;
            }
        }

        public void RejectAllOverdraftRequests()
        {
            RejectRequests(OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending));
        }

        public void RejectOverdraftRequestsAmount(double amount)
        {
            var pendingRequests = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            RejectRequests(pendingRequests.Where(o => o.Amount >= amount));

        }

        public void RejectOverdraftRequestsId(int id)
        {
            var pendingRequests = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            RejectRequests(pendingRequests.Where(o => o.Id == id));
        }
    }
}

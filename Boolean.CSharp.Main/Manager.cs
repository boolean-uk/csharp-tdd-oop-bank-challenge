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

        public List<OverdraftRequest> ApproveAllOverdraftRequests()
        {
            List<OverdraftRequest> newlyApproved = new List<OverdraftRequest>();
            foreach (var overdraft in OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending))
            {
                overdraft.Status = OverdraftStatus.Approved;
                newlyApproved.Add(overdraft);
            }
            return newlyApproved;
        }

        public List<OverdraftRequest> ApproveOverdraftRequestsAmount(double amount)
        {
            List<OverdraftRequest> newlyApproved = new List<OverdraftRequest>();
            var pendingOverdrafts = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            foreach (var overdraft in pendingOverdrafts.Where(o => o.Amount <= amount))
            {
                overdraft.Status = OverdraftStatus.Approved;
                newlyApproved.Add(overdraft);
            }
            return newlyApproved;
        }

        public List<OverdraftRequest> ApproveOverdraftRequestsId(int id)
        {
            List<OverdraftRequest> newlyApproved = new List<OverdraftRequest>();
            var pendingOverdrafts = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            foreach (var overdraft in pendingOverdrafts.Where(o => o.Id == id))
            {
                overdraft.Status = OverdraftStatus.Approved;
                newlyApproved.Add(overdraft);
            }
            return newlyApproved;

        }

        public void RejectAllOverdraftRequests()
        {
            foreach (var overdraft in OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending))
            {
                overdraft.Status = OverdraftStatus.Rejected;
            }
        }

        public void RejectOverdraftRequestsAmount(double amount)
        {
            var pendingOverdrafts = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            foreach (var overdraft in pendingOverdrafts.Where(o => o.Amount >= amount))
            {
                overdraft.Status = OverdraftStatus.Rejected;
            }

        }

        public void RejectOverdraftRequestsId(int id)
        {
            var pendingOverdrafts = OverdraftRequests.Where(o => o.Status == OverdraftStatus.Pending);
            foreach (var overdraft in pendingOverdrafts.Where(o => o.Id == id))
            {
                overdraft.Status = OverdraftStatus.Rejected;
            }
        }
    }
}

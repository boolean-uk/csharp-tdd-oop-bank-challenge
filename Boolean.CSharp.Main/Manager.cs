using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : Person, Imanager
    {
        string ssn {  get; set; }   
        Bank bank { get; set; }
        List<Request> requests { get; set; }= new List<Request>();
        public Manager(string Ssn, Bank Bank) :base(Ssn, Bank)
        {
            ssn = Ssn;
            bank = Bank;
        }
        public void FetchRequests()
        {
            requests = bank.UpdateRequests();
        }
        public string ActivateSmsStatements()
        {
            throw new NotImplementedException();
        }

        public void ApproveOverdraft(Request request)
        {
            bank.requests.Remove(request);
            bank.approvedRequests.Add(request);
        }
        public void RejectOverdraft(Request request)
        {
            bank.requests.Remove(request);
        }
        public void CreateCurrentAccount()
        {
            throw new NotImplementedException();
        }

        public void CreateSavingsAccount()
        {
            throw new NotImplementedException();
        }

        public string GenerateBankStatements()
        {
            throw new NotImplementedException();
        }

        public Request RequestOverdraft()
        {
            throw new NotImplementedException();
        }
    }
}

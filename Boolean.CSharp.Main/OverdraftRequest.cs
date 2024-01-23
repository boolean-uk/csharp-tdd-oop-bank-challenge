using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        public int Id { get; set; }
        public DateTime RequestTime { get; set; }
        public OverdraftStatus Status { get; set; }
        public double Amount { get; set; }

        public OverdraftRequest(int id, double amount)
        {
            Id = id;
            RequestTime = DateTime.Now;
            Amount = amount;
            if (amount <= 0) { Status = OverdraftStatus.Approved; }
            else { Status = OverdraftStatus.Pending; }
        }
    }
}

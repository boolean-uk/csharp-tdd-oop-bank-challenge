using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.PersonType
{
    public class Manager
    {
        string name { get; set; }
        public bool RespondToOverdraft(Customer customer, string response)
        {
            string finalResponse = response.ToLower();
            if (finalResponse == "approve")
            {
                return true;
            }
            return false;
        }
    }
}

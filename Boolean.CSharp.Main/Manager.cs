using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : IPerson
    {

        public Manager(string name) : base(name)
        {
            this.isManager = true;
        }

        public bool ApproveOverdraft(decimal amount)
        {

            if(amount <= 2000)
            {
                
                return true;
            }

            return false;
        }
    }
}

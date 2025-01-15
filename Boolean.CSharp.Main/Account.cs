using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
   
    {
       
        public Account()
        {
       
           
        }
        public abstract double Balance { get; set; }    

        public abstract string Accountid { get ; set; }
    
    }
}

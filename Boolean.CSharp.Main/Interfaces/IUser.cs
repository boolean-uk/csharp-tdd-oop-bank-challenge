using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<List<Transaction>> AccountsList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boolean.CSharp.Main.Users
{
    /// <summary>
    /// Class Engineer inheritates from the interface IUser.
    /// The ID of the engineer should b 0XXX
    /// </summary>
    public class Engineer : IUsers
    {
        private string _name;
        private int _Id;
        private bool _IsActive = true;
        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _Id; } set { _Id = value; } }
        public bool IsActive { get { return _IsActive; } }

    }
}

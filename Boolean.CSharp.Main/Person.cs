
using Boolean.CSharp.Main.Enum;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Person
    {
        public string Name { get; set; }
        public Role Role { get; set; }
        public Person(string name, Role role)
        {
            this.Name = name;
            this.Role = role;
        }                      
    }
}

﻿using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Customers
{
    public class Joaquin : ICustomer
    {
        public string name { get; set; }

        public Joaquin()
        {
            this.name = "Joaquin";
        }

        public string GetName()
        {
            return this.name;
        }
    }
}

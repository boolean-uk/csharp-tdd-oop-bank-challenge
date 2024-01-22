using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.IUsers
{
    public class BankManager : IUser
    {
        private string name;
        private string phoneNumber;
        private bool hasCurrentAccount = false;
        private bool hasSavingsAccount = false;

        public BankManager(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
        public string Name { get => this.name; set => this.name = value; }
        public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }
        public bool HasCurrentAccount { get => this.hasCurrentAccount; set => this.hasCurrentAccount = value; }
        public bool HasSavingsAccount { get => this.hasSavingsAccount; set => this.hasSavingsAccount = value; }
    }
}

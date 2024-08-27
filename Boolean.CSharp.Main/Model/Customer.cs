using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{

    internal class Customer
    {

        private string _name;
        private List<IAccount> _accounts;
        private readonly string _customerId;
        private readonly DateTime _created;
        private readonly string _docPath;

        internal Customer(string name, string socialsecurity) 
        { 
            this._name = name;
            this._created = DateTime.Now;
            this._customerId = socialsecurity;
            this._accounts = new List<IAccount>();
            this._docPath = $"..\\..\\..\\..\\Boolean.CSharp.Main\\DataBaseFolder\\{_customerId}\\";
            bool exists = System.IO.Directory.Exists(_docPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(_docPath);
        }

        internal string Name { get { return _name; } }
        internal List<IAccount> Accounts { get { return _accounts; } }

        internal string CustomerId { get { return _customerId; } }

        public Controler.MainControler CreatesAndControlsCustomer
        {
            get => default;
            set
            {
            }
        }

        internal bool CreateAccount(string name)
        {
            try
            {
                IAccount account = new SavingsAccount(name, _docPath);
                _accounts.Add(account);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            } 
        }

        internal List<IAccount> getaccounts() { return _accounts; }

    }
}

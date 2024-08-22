using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    /// <summary>
    /// Savings Accounts can't have a negative ballance.
    /// Would restrict number of withdraws per month/year, but thats too far out of scope
    /// </summary>
    public class SavingsAccount : IAccount
    {
        private readonly string _name;
        private readonly string _id;
        private readonly DateTime _created;
        private readonly string _docPath;

        public SavingsAccount(string name)
        {
            _name = "Savings Account: " + name;
            _id = Guid.NewGuid().ToString();
            _created = DateTime.Now;
            _docPath = $"..\\..\\..\\..\\Boolean.CSharp.Main\\DataBaseFolder\\";
            Console.WriteLine(_docPath);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt")))
            {
                outputFile.WriteLine(_name);
                outputFile.WriteLine("date       || credit  || debit  || balance");
            }
        }

        public bool DepositFunds(double funds) { return false; }

        public bool WithdrawFunds(double funds) { return false; }

        


    }
}

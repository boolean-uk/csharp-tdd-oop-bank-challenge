using Newtonsoft.Json;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    /// <summary>
    /// An account of some sort
    /// </summary>
    internal class SavingsAccount : IAccount
    {
        private readonly string _name;
        private readonly string _id;
        private readonly DateTime _created;
        private readonly string _docPath;
        private string _branch;

        internal SavingsAccount(string name, string path)
        {
            this._name = name;
            this._id = Guid.NewGuid().ToString();
            this._created = DateTime.Now;
            this._docPath = path;
            StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"));
            outputFile.Close();
            this._branch = "Default";
        }

        public void DepositFunds(double funds)
        {
            double balance = 0;
            string s;
            using (StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split("|".ToCharArray());
                    balance = Convert.ToDouble(fields[3]);
                }
                sr.Close();
            }

            s = $"{DateTime.Now}|    |{funds}|{balance+funds}";

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"), true))
            {
                outputFile.WriteLine(s);
                outputFile.Close();
            }
        }

        public void WithdrawFunds(double funds) 
        {
            double balance = 0;
            string s;
            using (StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split("|".ToCharArray());
                    balance = Convert.ToDouble(fields[3]);
                }
                sr.Close();
            }
            s = $"{DateTime.Now}|{funds}|    |{balance-funds}";

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"), true))
            {
                outputFile.WriteLine(s);
                outputFile.Close();
            }
        }

        public List<string> GenerateBankStatment() 
        {
            List<string> statment = new List<string>();
            statment.Add($"{_name}  Id: {_id}");
            statment.Add($"=================================================");
            statment.Add("    Date-Time       || Credit || Debit || Balance");
            using (StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split("|".ToCharArray());
                    statment.Add($"{fields[0]} ||  {fields[1]}  ||  {fields[2]}  || {fields[3]}");
                }
                sr.Close();
            }
            return statment;
        }

        public string GetBalance()
        {
            using StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt"));
            string line1 = "XX";
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split("|".ToCharArray());
                line1 = fields[3];
                
            }
            sr.Close(); 
            return line1;
        }

        public string GetAccountName()
        {
            return _name;
        }

        public string GetBranch() { return _branch; }
        public void SetBranch(string branch) { _branch = branch; }
    }
}

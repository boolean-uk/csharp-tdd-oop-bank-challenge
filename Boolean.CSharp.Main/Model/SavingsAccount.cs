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
            StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"));
            outputFile.Close();
        }

        public void DepositFunds(double funds)
        {
            double balance = funds;
            string s;
            using (StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split("|".ToCharArray());
                    balance += Convert.ToDouble(fields[3]);
                }
                sr.Close();
            }
            Console.WriteLine(balance);


            s = $"{DateTime.Now}|    |{funds}|{balance}";
            Console.WriteLine(s);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"), true))
            {
                outputFile.WriteLine(s);
                outputFile.Close();
            }
        }

        public void WithdrawFunds(double funds) 
        {
            double balance = -funds;
            string s;


            using (StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split("|".ToCharArray());
                    balance += Convert.ToDouble(fields[3]);
                }
                sr.Close();
            }
            Console.WriteLine(balance);



            s = $"{DateTime.Now}|{funds}|    |{balance}";
            Console.WriteLine(s);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"), true))
            {
                outputFile.WriteLine(s);
                outputFile.Close();
            }
        }

        public List<string> GenerateBankStatment() 
        {
            List<string> statment = new List<string>();
            statment.Add($"{_name}  Id: {_name}");
            statment.Add("date       || credit  || debit  || balance");
            using (StreamReader sr = new StreamReader(Path.Combine(_docPath, $"{_id}.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split("|".ToCharArray());
                    statment.Add($"{fields[0]} || {fields[1]}  || {fields[2]} || {fields[3]}");
                }
                sr.Close();
            }

            return statment;
        }




        


    }
}

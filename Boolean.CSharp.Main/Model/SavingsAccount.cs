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

        internal SavingsAccount(string name, string path)
        {
            _name = "Savings Account: " + name;
            _id = Guid.NewGuid().ToString();
            _created = DateTime.Now;
            _docPath = path;
            StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, $"{_id}.txt"));
            outputFile.Close();
        }

        internal void DepositFunds(double funds)
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

        internal void WithdrawFunds(double funds) 
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

        internal List<string> GenerateBankStatment() 
        {
            List<string> statment = new List<string>();
            statment.Add($"{_name}  Id: {_id}");
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

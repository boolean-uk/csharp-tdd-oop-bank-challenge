using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankStatements
    {
        string date;
        double amount;
        double balance;
        Account account;
        string type;
        
        public BankStatements(string date, double amount, string type,double balance,Account account)
        {
            this.date = date;
            this.amount = amount;
            this.type = type; 
            this.balance = balance;
            this.account = account; 
        }
        public string Date { get { return date; } }

        public double Amount {  get { return amount; } }    

        public string Type { get { return type; } } 
        public double Balance { get { return balance; } set { balance = value; } }

        public Account Account { get { return account; } }  

       

        public override string ToString()
        {

            if (account is CurrentAccount)
            {

                if (type == "withdrawal")
                {
                    return date + "||         ||  " + amount + " || " + balance + "|| CurrentAccount ";
                }
                else
                {
                    return date + "||" + amount + "     ||       || " + balance + "|| CurrentAccount";
                }
            }
            else
            {

                if (type == "withdrawal")
                {
                    return date + "||         ||  " + amount + " || " + balance + "|| SavingsAccount ";
                }
                else
                {
                    return date + "||" + amount + "     ||       || " + balance + "|| SavingsAccount";
                }

            }
        }
    }
}

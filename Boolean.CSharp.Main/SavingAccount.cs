using exercise.main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingAccount : IAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public Dictionary<int, decimal> AccountBalance { get; set; } = new Dictionary<int, decimal>();

        public SavingAccount(int accountNumber)
        { 
            this.AccountNumber = accountNumber;
        }

        public decimal Deposit(decimal amount)
        {
            decimal credit = 0;

            if (amount < 0)
            {
                amount = 0;
            }
            decimal value = AccountBalance.FirstOrDefault(t => t.Key == this.AccountNumber).Value;

            credit = value += amount;

            AccountBalance[AccountNumber] = credit;

            Transaction transaction = new Transaction(DateTime.Now, amount, credit, 0);

            string trans = transaction.GetTransaction();
            SMSService sms = new SMSService();
            sms.SendSMS(trans);


            return credit;
        }

        public decimal Withdraw(decimal amount)
        {
            decimal debit = 0;
            decimal value = AccountBalance.FirstOrDefault(t => t.Key == this.AccountNumber).Value;
            if (amount > 0 && amount <= value)
            {
               debit = value -= amount;
            }
            else if (RequestOverdraft(amount))
            {
                debit = value -= amount;
            }


            AccountBalance[AccountNumber] = debit;
            Transaction transaction = new Transaction(DateTime.Now, amount, 0, debit);

            string trans = transaction.GetTransaction();
            SMSService sms = new SMSService();
            sms.SendSMS(trans);

            return debit;
        }
        public bool RequestOverdraft(decimal amount)
        {
            Manager manager = new Manager("Bob");
            if (manager.ApproveOverdraft(amount))
            {
                return true;
            }

            return false;
        }

    }
}

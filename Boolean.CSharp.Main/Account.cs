using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public BranchCode BranchCode { get; }
        private List<Transaction> transactions;
        private Queue<Overdraft> overdraftRequests;

        public Account(BranchCode branchCode)
        {
            this.BranchCode = branchCode;
            transactions = new List<Transaction>();
            overdraftRequests = new Queue<Overdraft>();
        }

        public float GetBalance()
        {
            float balance = 0f;
            foreach (var item in transactions)
            {
                if (item.IsCredit)
                {
                    balance += item.Amount;
                }
                else if (!item.IsCredit)
                {
                    balance -= item.Amount;
                }
            }
            return balance;
        }

        public bool DepositMoney(float amount)
        {
            if (amount > 0)
            {
                Transaction newTrans = new Transaction(amount, true);
                transactions.Add(newTrans);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WithdrawMoney(float amount)
        {
            if (amount <= GetBalance() && amount > 0)
            {
                Transaction newTrans = new Transaction(amount, false);
                transactions.Add(newTrans);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GenerateBankStatement()
        {
            float balance = GetBalance();
            List<string> transactionOutput = new List<string>();
            transactionOutput.Add("date\t\t||credit||debit\t||balance");

            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                float tempBalance = balance;
                var date = transactions[i].transactionDate.ToString("dd-MM-yyyy");
                string credit = "";
                string debit = "";
                if (transactions[i].IsCredit)
                {
                    credit = transactions[i].Amount.ToString();
                    balance -= transactions[i].Amount;

                }
                else
                {
                    debit = transactions[i].Amount.ToString();
                    balance += transactions[i].Amount;
                }
                transactionOutput.Add($"{date}\t||{credit}\t||{debit}\t||{tempBalance}");
                tempBalance = balance;
            }

            foreach (var item in transactionOutput)
            {
                Console.WriteLine(item);
            }
            return transactionOutput;
        }

        public bool RequestOverdraft(float amount)
        {
            float balance = GetBalance();
            if (amount <= 0) { return false; }
            if (amount - balance <= 0) { return false; }
            overdraftRequests.Enqueue(new Overdraft(amount));
            return true;
        }

        public bool RejectOverdraft()
        {
            return overdraftRequests.TryDequeue(out _);
        }

        public bool ApproveOverdraft()
        {
            Overdraft overdraft;
            overdraftRequests.TryDequeue(out overdraft);
            if (overdraft == null) { return false; }

            transactions.Add(overdraft);
            return true;
        }

        public bool RequestSMSNotification(Account account, string fromTwilioNr, string recivingNr)
        {
            /*
            Console.WriteLine("Twilio NR to send from: ");
            string sendingNr = Console.ReadLine();
            Console.WriteLine("Who is the reciver: ");
            string recivingNr = Console.ReadLine();
            */

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            if (accountSid == null || authToken == null) { return false; }

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Your current balance is: " + GetBalance().ToString(),
                from: new Twilio.Types.PhoneNumber(fromTwilioNr),
                to: new Twilio.Types.PhoneNumber(recivingNr)
            );

            return true;
        }

    }

    public class CurrentAccount : Account
    {
        public CurrentAccount(BranchCode branchCode) : base(branchCode) { }

    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(BranchCode branchCode) : base(branchCode) { }
    }
}

public enum BranchCode
{
    LOND,
    STOC,
    NEWY,
    MADR
}



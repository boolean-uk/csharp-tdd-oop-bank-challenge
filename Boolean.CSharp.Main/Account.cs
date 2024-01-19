using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _number;
        private int _customerId;
        private BranchLocation _branch;
        private List<Transaction> _transactions = new List<Transaction>();
        private List<Overdraft> _overdraftRequests = new List<Overdraft>();

        public Account(Customer customer, BranchLocation branch)
        {
            _number = GenerateAccountNumber();
            _customerId = customer.Id;
            _branch = branch;
        }

        private string GenerateAccountNumber()
        {
            /** NOTE:
             * generate an 7-digit random number as presented here:
             * https://stackoverflow.com/a/14734156
             * change string to an 8-digit format as presented here:
             * https://stackoverflow.com/a/44383892
            */
            Random rnd = new Random();
            int myRandomNo= rnd.Next(0, 9999999);
            return myRandomNo.ToString("00000000");
        }

        private void Transact(TransactionType type, decimal amount)
        {
            _transactions.Insert(0, new Transaction(DateTime.Now, type, amount, GetBalance()));
        }

        private decimal GetOverdraftFunds()
        {
            decimal total = 0.0m;
            _overdraftRequests.Where(r => r.Status == OverdraftStatus.Approved).ToList().ForEach(r => total += r.Amount);
            return total;
        }

        public decimal GetBalance()
        {
            if (_transactions.Count == 0)
                return 0.0m;
            
            // NOTE: keep _transactions list sorted (most frequent transaction first), so that the balance is always accessible by retrieving the NewBalance from the first element
            return _transactions[0].NewBalance;
        }

        public void Deposit(decimal amount)
        {
            Transact(TransactionType.Credit, amount);
        }

        public bool Withdraw(decimal amount)
        {
            decimal fundsAvailable = GetBalance() + GetOverdraftFunds();

            if (fundsAvailable < amount)
                return false;

            Transact(TransactionType.Debit, amount);
            return true;
        }

        public string GetBankStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{"date",-10} || {"credit",-7} || {"debit",-6} || {"balance",-6}");

            _transactions.ForEach(t => sb.Append('\n').Append(t.ToString()));

            return sb.ToString();
        }

        public int RequestOverdraft(Customer customer, decimal amount)
        {
            if (customer.Id != _customerId)
                return -1;
            Overdraft overdraft = new Overdraft(amount);
            _overdraftRequests.Add(overdraft);
            return overdraft.Id;
        }

        private bool HandleOverdraftRequest(BankManager manager, int overdraftId, OverdraftStatus status)
        {
            Overdraft overdraft = _overdraftRequests.Find(r => r.Id == overdraftId);
            if (overdraft is null)
                return false;
            overdraft.Status = status;
            return true;
        }

        public bool ApproveOverdraftRequest(BankManager manager, int overdraftId)
        {
            return HandleOverdraftRequest(manager, overdraftId, OverdraftStatus.Approved);
        }

        public bool RejectOverdraftRequest(BankManager manager, int overdraftId)
        {
            return HandleOverdraftRequest(manager, overdraftId, OverdraftStatus.Rejected);
        }

        public string Number { get => _number; }
        public BranchLocation Branch { get => _branch; }
    }
}

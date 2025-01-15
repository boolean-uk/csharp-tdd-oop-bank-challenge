using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        private float _overdraftAmount;
        private OverdraftRequest? _overdraftRequest;

        public CurrentAccount(Guid ownerID, string accountName) : base(ownerID, accountName)
        {
            _overdraftAmount = 0f;
        }

        // Deposit is same as a transaction from no one
        public void Deposit(float amount)
        {
            if (amount <= 0)
                return;
            
            Transaction deposit = new Transaction(null, this.AccountNumber, amount);

            BankData.Transactions.Add(deposit);
        }

        // Withdraw is same as a transaction to no one
        public void Withdraw(float amount)
        {
            if (amount <= 0)
                return;

            if (CalculateFunds() - amount < -this.OverdraftAmount)
                return;

            Transaction withdraw = new Transaction(this.AccountNumber, null, amount);

            BankData.Transactions.Add(withdraw);
        }


        public void RequestOverdraft(float amount)
        {
            if (amount <= 0)
                return;

            _overdraftRequest = new OverdraftRequest(this.AccountNumber, amount);

            // A manager would theoretically be notified about the overdraft request here
        }

        public void ManageOverdraftRequest(Role role, bool approve)
        {
            if (role == Role.Manager) // Only manager can approve/deny request
            {
                if (!_overdraftRequest.HasValue)
                    return;
                if (approve)
                    _overdraftAmount = _overdraftRequest.Value.Amount;
            _overdraftRequest = null;
            }
        }

        public float OverdraftAmount { get { return _overdraftAmount; } }
        public OverdraftRequest? OverdraftRequest { get { return _overdraftRequest; } }
    }
}

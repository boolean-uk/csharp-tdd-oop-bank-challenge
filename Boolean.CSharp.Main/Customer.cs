﻿using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private List<IAccount> _accounts = [];
        public void CreateAccount(IAccount account)
        {
            _accounts.Add(account);
        }

        public List<IAccount> GetAccounts()
        {
            return _accounts;
        }

        public int GetNumberOfAccounts()
        {
            return _accounts.Count;
        }

        public void RequestOverdraft(Request request)
        {
            request.Account.Branch.Requests.Add(request);
        }
    }
}

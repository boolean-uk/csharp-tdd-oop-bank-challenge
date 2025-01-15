using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void createBank()
        {
            Bank bank = new Bank(); 
            Assert.Pass();
        }
        
        [Test]
        public void bank_addCurrentAccount()
        {
            Bank bank = new Bank();

            int accountId = bank.AddAccount<CurrentAccount>("Bob", "my first account");
            Assert.That(accountId != -1);
        }

        [Test]
        public void bank_addSavingAccount()
        {
            Bank bank = new Bank();

            int accountId = bank.AddAccount<SavingsAccount>("Dingo", "myFirst acc");

            Assert.That(accountId != -1);
        }
        
        [Test]
        public void SavingAccount_getBalance()
        {
            Bank bank = new Bank();
            SavingsAccount acc = Account.Create<SavingsAccount>(bank, 0, Branch.Stockholm, "bob", "bobbys holiday money");

            Assert.That(acc.GetBalance == 0);
        }
        [Test]
        public void SavingAccount_deposit()
        {
            Bank bank = new Bank();
            SavingsAccount acc = Account.Create<SavingsAccount>(bank, 0, Branch.Stockholm, "bob", "bobbys holiday money");

            acc.deposit(50.0f);

            Assert.That(acc.GetBalance == 50.0f);
        }
        [TestCase(50.0f, 50.0f, 0,50.0f)]
        [TestCase(40.0f, 50.0f, 40.0f,null)]
        [TestCase(100.0f, 40.0f, 60.0f, 40.0f)]
        public void SavingAccount_depositThenWithdraw(float deposit, float withdraw, float expectedEndBalance, float? expectedWithdraw)
        {
            Bank bank = new Bank();
            SavingsAccount acc = Account.Create<SavingsAccount>(bank,0, Branch.Stockholm, "bob", "bobbys holiday money");

            acc.deposit(deposit);
            float? returned = acc.withdraw(withdraw);
            
            Assert.That(returned == expectedWithdraw);
            Assert.That(acc.GetBalance == expectedEndBalance);

        }
        [Test]
        public void SavingAccount_depositThenWithdraw_multipleTimes()
        {
            Bank bank = new Bank();
            SavingsAccount acc = Account.Create<SavingsAccount>(bank,0, Branch.Stockholm, "bob", "bobbys holiday money");

            List<Tuple<float, float, float>> deposit_withdraw_expected = new()
            {
                new(30,30,0),
                new(30,10,20),
                new(100,0,120),
                new(100,10,210),
                new(0,0,210),
                new(0,30,180),
                new(0,50,130),
                new(1,0,131),
                new(1,0,132),
                new(1,0,133),
                new(2,0,135),
                new(0,35,100),
            };

            foreach (var t in deposit_withdraw_expected)
            {
                float dep = t.Item1;
                float wit = t.Item2;
                float exp = t.Item3;

                if(dep != 0) 
                    acc.deposit(dep);
                if(wit != 0)
                {
                    float ? returned = acc.withdraw(wit);

                    Assert.That(returned == wit); // All test expects that we never withdraw more than exists
                }

                Assert.That(acc.GetBalance == exp);
            }

        }
        [Test]
        public void bank_SavingAccount_depositThenWithdraw_multipleTimes()
        {
            Bank bank = new Bank();
            int acc = bank.AddAccount<SavingsAccount>("bob", "savings to a Ps5");
            

            List<Tuple<float, float, float>> deposit_withdraw_expected = new()
            {
                new(30,30,0),
                new(30,10,20),
                new(100,0,120),
                new(100,10,210),
                new(0,0,210),
                new(0,30,180),
                new(0,50,130),
                new(1,0,131),
                new(1,0,132),
                new(1,0,133),
                new(2,0,135),
                new(0,35,100),
            };

            foreach (var t in deposit_withdraw_expected)
            {
                float dep = t.Item1;
                float wit = t.Item2;
                float exp = t.Item3;

                if (dep != 0)

                    bank.deposit(acc, dep);
                if(wit != 0)
                {
                    float ? returned = bank.withdraw(acc,wit);

                    Assert.That(returned == wit); // All test expects that we never withdraw more than exists
                }

                Assert.That(bank.getBalance(acc) == exp);
            }

        }
        [Test]
        public void bank_SavingAccount_deposit()
        {
            Bank bank = new Bank();
            //SavingsAccount account = new SavingsAccount();
            int accountId = bank.AddAccount<SavingsAccount>("Bob", "my first account");


            bank.deposit(accountId, 50.0f);

            Assert.That(bank.getBalance(accountId) == 50.0f);
        }
        
        [Test]
        public void bank_CurrentAccount_RequestOverdraft()
        {
            Bank bank = new Bank();
            int accountId = bank.AddAccount<CurrentAccount>("Bob", "my first account");

            bank.requestOverdraft(accountId, 100.0f);

            var  banktype = bank.GetType();
            var requestedOverdraftsField = banktype.GetField("_requestedOverdrafts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var requestedOverdrafts = (Dictionary<int, float>)requestedOverdraftsField.GetValue(bank);

            Assert.That(requestedOverdrafts.Count == 1);
        }
        [Test]
        public void bank_CurrentAccount_RequestOverdraft_invalidAccountType()
        {
            Bank bank = new Bank();
            int accountId = bank.AddAccount<SavingsAccount>("Bob", "my first account");

            bank.requestOverdraft(accountId, 100.0f);

            var  banktype = bank.GetType();
            var requestedOverdraftsField = banktype.GetField("_requestedOverdrafts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var requestedOverdrafts = (Dictionary<int, float>)requestedOverdraftsField.GetValue(bank);

            Assert.That(requestedOverdrafts.Count == 0);
        }
        
        [Test]
        public void bank_CurrentAccount_RequestOverdraft_approve()
        {
            Bank bank = new Bank();
            //SavingsAccount account = new SavingsAccount();
            int accountId = bank.AddAccount<CurrentAccount>("Bob", "my first account");

            var withdrawnBeforeRequest = bank.withdraw(accountId, 50.0f);

            bank.requestOverdraft(accountId, 100.0f);

            var withdrawnAfterRequest = bank.withdraw(accountId, 50.0f);

            var  banktype = bank.GetType();
            var requestedOverdraftsField = banktype.GetField("_requestedOverdrafts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var requestedOverdrafts = (Dictionary<int, float>)requestedOverdraftsField.GetValue(bank);

            Assert.That(requestedOverdrafts.Count == 1);

            bank.handleOverdraftRequests(accountId, true);

            var withdrawnAfterApprove = bank.withdraw(accountId, 50.0f);

            var withdrawnAfterApprove_remaining = bank.withdraw(accountId, 50.0f);
            var withdrawnAfterApprove_NoRemaining = bank.withdraw(accountId, 50.0f);

            Assert.That(requestedOverdrafts.Count == 0);
            Assert.That(withdrawnBeforeRequest == 0);
            Assert.That(withdrawnAfterRequest == 0);
            Assert.That(withdrawnAfterApprove == 50.0f);
            Assert.That(withdrawnAfterApprove_remaining  == 50.0f);
            Assert.That(withdrawnAfterApprove_NoRemaining == 0.0f);
        }
        
        [Test]
        public void bank_CurrentAccount_RequestOverdraft_approve_multiUser()
        {
            Bank bank = new Bank();
            //SavingsAccount account = new SavingsAccount();
            int accountId_0 = bank.AddAccount<CurrentAccount>("Bam", "my first account");
            int accountId_1 = bank.AddAccount<CurrentAccount>("Bob", "my first account");
            int accountId_2 = bank.AddAccount<CurrentAccount>("Wam", "my first account");

            var withdrawnBeforeRequest = bank.withdraw(accountId_1, 50.0f);

            bank.requestOverdraft(accountId_1, 100.0f);
            bank.requestOverdraft(accountId_2, 10.0f);
            bank.requestOverdraft(accountId_0, 30.0f);

            var withdrawnAfterRequest = bank.withdraw(accountId_1, 50.0f);

            var  banktype = bank.GetType();
            var requestedOverdraftsField = banktype.GetField("_requestedOverdrafts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var requestedOverdrafts = (Dictionary<int, float>)requestedOverdraftsField.GetValue(bank);

            Assert.That(requestedOverdrafts.Count == 3);

            bank.handleOverdraftRequests(accountId_1, true);
            bank.handleOverdraftRequests(accountId_0, true);

            var withdrawnAfterApprove = bank.withdraw(accountId_1, 50.0f);

            
            var withdrawnAfterApprove_remaining_0 = bank.withdraw(accountId_0, 10.0f);
            var withdrawnAfterApprove_remaining = bank.withdraw(accountId_1, 50.0f);
            var withdrawnAfterApprove_NoRemaining_withdrawTooMuch_0 = bank.withdraw(accountId_0, 50.0f);
            var withdrawnAfterApprove_NoRemaining = bank.withdraw(accountId_1, 50.0f);

            Assert.That(requestedOverdrafts.Count == 1);
            Assert.That(withdrawnBeforeRequest == 0);
            Assert.That(withdrawnAfterApprove_remaining_0 == 10);
            Assert.That(withdrawnAfterApprove_NoRemaining_withdrawTooMuch_0 == 0);
            Assert.That(withdrawnAfterRequest == 0);
            Assert.That(withdrawnAfterApprove == 50.0f);
            Assert.That(withdrawnAfterApprove_remaining  == 50.0f);
            Assert.That(withdrawnAfterApprove_NoRemaining == 0.0f);
        }


        [Test]
        public void bank_CurrentAccount_requestStatement()
        {
            Bank bank = new Bank();
            int acc = bank.AddAccount<SavingsAccount>("bob", "savings to a Ps5");


            List<Tuple<float, float, float>> deposit_withdraw_expected = new()
            {
                new(30,30,0),
                new(30,10,20),
                new(100,0,120),
                new(100,10,210),
                new(0,0,210),
                new(0,30,180),
                new(0,50,130),
                new(1,0,131),
                new(1,0,132),
                new(1,0,133),
                new(2,0,135),
                new(0,35,100),
            };

            foreach (var t in deposit_withdraw_expected)
            {
                float dep = t.Item1;
                float wit = t.Item2;
                float exp = t.Item3;

                if (dep != 0)

                    bank.deposit(acc, dep);
                if (wit != 0)
                {
                    float? returned = bank.withdraw(acc, wit);
                }
            }

            string accountStatement = bank.requestAccountStatement(acc);
            Assert.That(accountStatement.Length > 10);
        }
        
        [Test]
        public void bank_CurrentAccount_requestStatement_presentSms()
        {
            Bank bank = new Bank();
            int acc = bank.AddAccount<SavingsAccount>("bob", "savings to a Ps5");


            List<Tuple<float, float, float>> deposit_withdraw_expected = new()
            {
                new(30,30,0),
                new(30,10,20),
                new(100,0,120),
                new(100,10,210),
                new(0,0,210),
                new(0,30,180),
                new(0,50,130),
                new(1,0,131),
                new(1,0,132),
                new(1,0,133),
                new(2,0,135),
                new(0,35,100),
            };

            foreach (var t in deposit_withdraw_expected)
            {
                float dep = t.Item1;
                float wit = t.Item2;
                float exp = t.Item3;

                if (dep != 0)

                    bank.deposit(acc, dep);
                if (wit != 0)
                {
                    float? returned = bank.withdraw(acc, wit);
                }
            }

            bank.presentAccountStatement(acc);
            Assert.Pass();
        }

        [Test]
        public void bank_SavingAccount_multipleDeposits()
        {
            Bank bank = new Bank();
            //SavingsAccount account = new SavingsAccount();
            int accountId = bank.AddAccount<SavingsAccount>("Bob", "my first account");


            bank.deposit(accountId, 50.0f);
            bank.deposit(accountId, 50.0f);
            bank.deposit(accountId, 50.0f);

            Assert.That(bank.getBalance(accountId) == 150.0f);
        }
        
        
        [Test]
        public void createRecord()
        {
            Bank bank = new Bank();
            SavingsAccount acc = Account.Create<SavingsAccount>(bank, 0, Branch.Stockholm, "bob", "bobbys holiday money");
            
            Record record = new Record(acc, 42, 0,1);

            Assert.Pass();
        }
        [Test]
        public void createSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            Assert.Pass();
        }
        [Test]
        public void createCurrentAccount()
        {
            CurrentAccount currentAccount = new CurrentAccount();
            Assert.Pass();
        }

    }

    
}
using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Users
{/// <summary>
 /// Class Manager inheritates from the interface IUser.
 /// The ID of the engineer should be 9XXX
 /// </summary>
    public class Manager : IUsers
    {
        private string _name;
        private int _Id;
        private bool _IsActive = true;
        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _Id; } set { _Id = value; } }
        public bool IsActive { get { return _IsActive; } }
        public List<Transaction> _request = new List<Transaction>();

        public void AddRequest(Transaction request)
        {
            _request.Add(request);
        }

        public List<Transaction> getRequests() { 
            return _request;
        }

        private void ApprovedRequest(Transaction request) {
            request.TransectionStatus = true;
        }
        private void DeniedRequest(Transaction request) {
            request.TransectionStatus = false;
        }

        public void reviewRequest() {
            Console.WriteLine("Getting requests to be reviewed, please wait.");
            if (_request.Count == 0)
            {
                throw new Exception("No request to be reviewed");
            }
            else
            {
                foreach (Transaction request in _request)
                {
                    Console.WriteLine($"A request: {{0,10}} || {{1,10}} || {{2,10}} ", "Date", "Amount", "Note");
                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} "
                    , request.DateInfo.ToShortDateString()
                    , request.Amount
                    , request.Mark
                    );
                    Console.WriteLine("\nApprove? (y for yes, n for no)");
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.KeyChar == 'y')
                    {
                        ApprovedRequest(request);
                    }
                    else if (input.KeyChar == 'n')
                    {
                        DeniedRequest(request);

                    }
                }
            }
        }
    }



}

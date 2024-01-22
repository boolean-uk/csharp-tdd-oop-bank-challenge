using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class Branch(string name, string description) : IBranch
    {
        public string Name => name;

        public string Description => description;

        public List<Request> Requests { get; set; } = [];

        public void ReviewRequests()
        {
            Console.WriteLine("\nRequest Reviews:");
            foreach (var request in Requests)
            {
                Console.WriteLine("{0,20}{1,20}{2,10}", "Account", "Reason", "Amount");
                Console.WriteLine("{0,20}{1,20}{2,10:0.00}", request.Account.Name, request.Reason, request.Amount);
                Console.WriteLine("\nApprove? (y for yes, n for no)");
                bool isReviewing = true;
                while (isReviewing) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.KeyChar == 'y')
                    {
                        request.Approved = true;
                    } else if (key.KeyChar == 'n')
                    {
                        request.Approved = false;
                    }
                    isReviewing = false;
                }
            }
        }
    }
}

using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes.User
{
    public class ManagerUser : IUser
    {
        public string ManageRequest(OverdraftRequest request, eStatus response)
        {
            if (request != null)
            {
                if (response == eStatus.Approved)
                {
                    request.RequestStatus = eStatus.Approved;
                    return "Your request has been approved";
                }
                else if (response == eStatus.Denied)
                {
                    request.RequestStatus = eStatus.Approved;
                    return "Your request has been denied";
                }
            }
            return "Error, your request can't be handled";
        }
    }
}

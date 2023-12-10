using BSynchro.Application.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Application.Abstraction
{
    public interface ICustomerHelper
    {
        public string OpenAccount(int customerID, decimal initialCredit);
        public UserInfoResponse UserInfo(int customerId);

    }
}

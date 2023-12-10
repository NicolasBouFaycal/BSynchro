using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Application.CustomModels
{
    public class UserInfoResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<TransactionInfo> Transactions { get; set; }
    }

    public class TransactionInfo
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }

}

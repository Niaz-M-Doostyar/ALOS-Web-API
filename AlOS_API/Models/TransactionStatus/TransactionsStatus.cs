using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlOS_API.Models.TransactionStatus
{
    public class TransactionsStatus
    {
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string PinCode { get; set; }
        public string UniquerId { get; set; }
    }
}

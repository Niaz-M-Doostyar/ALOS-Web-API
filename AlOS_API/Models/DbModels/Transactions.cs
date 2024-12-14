using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Transactions
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int Uid { get; set; }
        public long? TrnNo { get; set; }
        public string TrnDate { get; set; }
        public string PartnerId { get; set; }
        public string Service { get; set; }
        public string Provider { get; set; }
        public string CustomerNo { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string SuccessToRefund { get; set; }
        public string FailToSucdeb { get; set; }
        public string OprId { get; set; }
        public string ApiName { get; set; }
        public string Source { get; set; }
        public string RechargeRequest { get; set; }
        public string RechargeResponce { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

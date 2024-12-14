using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class ApiLogs
    {
        public uint Id { get; set; }
        public string RechargeId { get; set; }
        public DateTime TrnDate { get; set; }
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Provider { get; set; }
        public string CustomerNo { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string ProviderResponse { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

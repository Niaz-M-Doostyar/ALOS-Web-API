using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class TopupDeliveries
    {
        public uint Id { get; set; }
        public string FirmName { get; set; }
        public string CountryName { get; set; }
        public string PaymentMode { get; set; }
        public string DepositbankName { get; set; }
        public string DepositAC { get; set; }
        public string OrderDate { get; set; }
        public string RefNo { get; set; }
        public string TopupDate { get; set; }
        public string TopupAmount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string OrderAmount { get; set; }
        public string UpdatedBy { get; set; }
        public string Receipt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Topuptransfers
    {
        public uint Id { get; set; }
        public string TrnNo { get; set; }
        public string User { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string PaymentMode { get; set; }
        public string RefNo { get; set; }
        public string Receipt { get; set; }
        public string Stutus { get; set; }
        public string UpdatedBy { get; set; }
        public string AccountNo { get; set; }
        public string PbankName { get; set; }
        public string OrgBankName { get; set; }
        public string OrgBranchName { get; set; }
        public string OrgAccNo { get; set; }
        public string OrgCheckNo { get; set; }
        public string OrgCheckDate { get; set; }
        public string TopupBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

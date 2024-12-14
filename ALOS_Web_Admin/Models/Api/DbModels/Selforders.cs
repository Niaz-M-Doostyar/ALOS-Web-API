using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class Selforders
    {
        public uint Id { get; set; }
        public int AdminId { get; set; }
        public string Amount { get; set; }
        public string Remark { get; set; }
        public string Wallet { get; set; }
        public string Status { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

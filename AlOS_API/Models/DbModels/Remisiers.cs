using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Remisiers
    {
        public uint Id { get; set; }
        public string Uid { get; set; }
        public string Type { get; set; }
        public string OpeningBalance { get; set; }
        public string Amount { get; set; }
        public string ClosingBalance { get; set; }
        public string Module { get; set; }
        public string Remark { get; set; }
        public string TrnNo { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

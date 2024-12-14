using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Apis
    {
        public uint Id { get; set; }
        public string ClientOrderId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

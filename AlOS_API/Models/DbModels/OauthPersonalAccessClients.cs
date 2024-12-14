using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class OauthPersonalAccessClients
    {
        public ulong Id { get; set; }
        public ulong ClientId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

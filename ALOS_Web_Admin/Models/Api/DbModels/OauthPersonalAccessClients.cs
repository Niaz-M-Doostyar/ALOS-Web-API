using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class OauthPersonalAccessClients
    {
        public ulong Id { get; set; }
        public ulong ClientId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

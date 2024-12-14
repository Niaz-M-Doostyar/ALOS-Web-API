using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class OauthAuthCodes
    {
        public string Id { get; set; }
        public ulong UserId { get; set; }
        public ulong ClientId { get; set; }
        public string Scopes { get; set; }
        public bool Revoked { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}

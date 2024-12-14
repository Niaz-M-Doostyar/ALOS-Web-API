using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class OauthRefreshTokens
    {
        public string Id { get; set; }
        public string AccessTokenId { get; set; }
        public bool Revoked { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}

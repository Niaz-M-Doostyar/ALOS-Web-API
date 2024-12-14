using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class OauthRefreshTokens
    {
        public string Id { get; set; }
        public string AccessTokenId { get; set; }
        public bool Revoked { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}

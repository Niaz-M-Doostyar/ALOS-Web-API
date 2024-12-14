using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class OauthClients
    {
        public ulong Id { get; set; }
        public ulong? UserId { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string Provider { get; set; }
        public string Redirect { get; set; }
        public bool PersonalAccessClient { get; set; }
        public bool PasswordClient { get; set; }
        public bool Revoked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

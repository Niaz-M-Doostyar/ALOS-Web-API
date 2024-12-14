using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class PasswordResets
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

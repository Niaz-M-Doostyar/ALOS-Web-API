using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class Agents
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string Mobile { get; set; }
        public string Companyname { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string RememberToken { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

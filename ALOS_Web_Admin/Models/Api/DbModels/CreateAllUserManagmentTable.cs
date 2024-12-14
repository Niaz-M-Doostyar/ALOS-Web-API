using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class CreateAllUserManagmentTable
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int PinCode { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

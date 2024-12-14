using System;
using Microsoft.AspNetCore.Identity;

namespace ALOS_Web_Admin.Models.Api.Authentication
{
    public class ApplicationUser :IdentityUser
    {
        public string PinCode { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string Commission { get; set; }
        public string Address { get; set; }
        public string RememberToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

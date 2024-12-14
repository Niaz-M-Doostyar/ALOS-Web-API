using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ALOS_API.Models.Authentication
{
    public class ApplicationUser:IdentityUser
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

using System;
using System.ComponentModel.DataAnnotations;

namespace ALOS_Web_Admin.Models.Api.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        [Required]
        public string PinCode { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Country { get; set; }
        public string Commission { get; set; }
        public string Address { get; set; }
        public string RememberToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

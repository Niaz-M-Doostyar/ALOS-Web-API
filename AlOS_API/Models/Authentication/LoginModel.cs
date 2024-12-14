using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALOS_API.Models.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Pin Code is required")]
        public string PinCode { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        public string Mobile { get; set; }

        public static bool LoginCheckViaMobileAndPinCode(string userMobile,string modelMobile, string userPinCode,string modelPinCode)
        {
            return string.Equals(userMobile,modelMobile) && string.Equals(userPinCode,modelPinCode)?true:false;
        }
    }
}

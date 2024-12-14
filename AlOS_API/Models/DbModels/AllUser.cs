using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class AllUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Companyname { get; set; }
        public string Pincode { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

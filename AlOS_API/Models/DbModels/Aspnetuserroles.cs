using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Aspnetuserroles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Aspnetroles Role { get; set; }
        public virtual Aspnetusers User { get; set; }
    }
}

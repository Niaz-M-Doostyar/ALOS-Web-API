﻿using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Aspnetuserclaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Aspnetusers User { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Aspnetuserlogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual Aspnetusers User { get; set; }
    }
}

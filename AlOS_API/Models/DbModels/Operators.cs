﻿using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Operators
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
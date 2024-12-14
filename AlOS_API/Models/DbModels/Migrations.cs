using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Migrations
    {
        public uint Id { get; set; }
        public string Migration { get; set; }
        public int Batch { get; set; }
    }
}

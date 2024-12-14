using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class Requestlogs
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class FailedJobs
    {
        public ulong Id { get; set; }
        public string Uuid { get; set; }
        public string Connection { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public string Exception { get; set; }
        public DateTime FailedAt { get; set; }
    }
}

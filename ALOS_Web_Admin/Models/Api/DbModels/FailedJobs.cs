using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
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

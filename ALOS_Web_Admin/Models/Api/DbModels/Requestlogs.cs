using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class Requestlogs
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

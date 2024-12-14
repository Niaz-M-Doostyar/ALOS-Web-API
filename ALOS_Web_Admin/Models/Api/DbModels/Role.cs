using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class Role
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

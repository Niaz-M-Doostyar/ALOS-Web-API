using System;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class ClientPermissions
    {
        public uint Id { get; set; }
        public int UserId { get; set; }
        public string Awcc { get; set; }
        public string Roshan { get; set; }
        public string Salaam { get; set; }
        public string Etisalat { get; set; }
        public string Mtn { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

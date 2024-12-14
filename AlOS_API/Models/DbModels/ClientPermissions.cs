using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
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

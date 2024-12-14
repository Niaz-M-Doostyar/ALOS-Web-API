using System;
using System.Collections.Generic;

namespace AlOS_API.Models.DbModels
{
    public partial class GroupMasters
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int Updateby { get; set; }
        public bool? Status { get; set; }
        public bool? SiteParamEdit { get; set; }
        public bool? GroupMasterList { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

using System.Collections.Generic;

namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class Aspnetroles
    {
        public Aspnetroles()
        {
            Aspnetroleclaims = new HashSet<Aspnetroleclaims>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
    }
}
